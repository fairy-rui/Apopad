using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using Apopad.Network.AutoMapper;
using SrimsOUC.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Apopad.Network
{
    public class Networking
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly SrimsContext srimsContext;

        private readonly IRepository<int, Person> personRepository;
        private readonly IRepository<int, KeyWords> keyWordsRepository;
        private readonly IRepository<int, AuthorShip> authorShipRepository;

        private Queue<CoAuthor> enQueue;
        private Queue<CoAuthor> deQueue;

        public Networking(IRepositoryContext repositoryContext, SrimsContext srimsContext)
        {
            this.repositoryContext = repositoryContext;
            this.srimsContext = srimsContext;

            personRepository = repositoryContext.GetRepository<int, Person>();
            keyWordsRepository = repositoryContext.GetRepository<int, KeyWords>();
            authorShipRepository = repositoryContext.GetRepository<int, AuthorShip>();

            enQueue = new Queue<CoAuthor>();
            deQueue = new Queue<CoAuthor>();
        }

        public int BuildKeywordSet()
        {
            int total = 0;

            var keywords = GetKeyWords(k => true, ref total)
                    .Select(k => k.MapTo<KeyWords>());
            foreach(var kw in keywords)
            {
                keyWordsRepository.Add(kw);
            }
            repositoryContext.Commit();

            return total;
        }

        public void BuildNetWork()
        {
            double count = BuildKeywordSet();
            //double count = 6199;

            var coreAuthors = GetCoreAuthors(a => true).ToList();
            foreach(var author in coreAuthors)
            {
                enQueue.Enqueue(author);
            }

            while(enQueue.Count > 0)
            {
                var coAuthor = enQueue.Dequeue();

                BuildCoAuthorNetWork(coAuthor);
                BuildAuthorKeyworkNetWork(coAuthor, count);

                deQueue.Enqueue(coAuthor);
            }

            repositoryContext.Commit();

            deQueue.Clear();
        }

        public void BuildAuthorKeyworkNetWork(CoAuthor author, double totalCount)
        {
            if(!authorShipRepository.Exists(a => a.PersonNo == author.Number))
            {
                return;
            }

            if (author.ExpertID.HasValue)
            {
                int authorTotal = 0;
                double maxCount = 0;

                var keywords = GetAuthorKeyWords(k => true, author.ExpertID.Value, ref authorTotal);
                if(keywords.Count() > 0)
                {
                    maxCount = keywords.First().Count;
                }

                var authorShip = authorShipRepository.FindAll(a => a.PersonNo == author.Number).First();
                foreach (var keyword in keywords)
                {
                    var key = keyWordsRepository.FindAll(k => k.Name == keyword.KeyWord).FirstOrDefault();
                    if(key != null && !authorShip.Keywords.Any(k => k.KeywordId == key.Id))
                    {
                        var weight = (keyword.Count / maxCount) * Math.Log((totalCount / authorTotal));
                        var akw = new AuthorKeyWord
                        {
                            AuthorId = authorShip.Id,
                            KeywordId = key.Id,
                            Weight = Math.Round(weight,4),
                        };
                        authorShip.Keywords.Add(akw);
                    }
                }

                repositoryContext.Commit();
            }
        }

        public void BuildCoAuthorNetWork(CoAuthor author)
        {
            if (author.ExpertID.HasValue && ExistOrAddAuthorShip(author))
            {
                var authorShip = authorShipRepository.FindAll(a => a.PersonNo == author.Number).First();                          
                var coAuthors = GetCoauthors(ca => true, author.ExpertID.Value).ToList();
                foreach (var ca in coAuthors)
                {
                    if (!enQueue.Any(q => q.Number == ca.Number) && !deQueue.Any(q => q.Number == ca.Number))
                    {
                        enQueue.Enqueue(ca);
                    }
                    
                    if (ExistOrAddAuthorShip(ca))
                    {
                        var caShip = authorShipRepository.FindAll(a => a.PersonNo == ca.Number).First();
                        //if (!authorShip.Coauthors.Any(a => a.CoauthorId == caShip.Id ||
                        //    a.CollaboratorId == caShip.Id))
                        if (!authorShip.Coauthors.Any(a => a.CollaboratorId == caShip.Id)
                            && !authorShip.Collaborators.Any(a => a.CoauthorId == caShip.Id))
                        {
                            var coAuthorShip = new CoAuthorShip
                            {
                                Coauthor = authorShip,
                                Collaborator = caShip,
                                Weight = ca.Count,
                            };
                            authorShip.Coauthors.Add(coAuthorShip);
                        }
                    }
                }

                repositoryContext.Commit();
            }
                       
        }

        private bool ExistOrAddAuthorShip(CoAuthor author)
        {
            var exists = authorShipRepository.Exists(a => a.PersonNo == author.Number);
            if (!exists)
            {
                var person = personRepository.FindAll(p => p.PersonNo == author.Number)
                                .FirstOrDefault();
                if (person != null)
                {
                    var ap = new AuthorShip
                    {
                        PersonId = person.Id,
                        PersonNo = person.PersonNo,
                        Name = person.NameCN,
                        EnglishName = person.NameEN,
                    };
                    authorShipRepository.Add(ap);
                    repositoryContext.Commit();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private IEnumerable<CoAuthor> GetCoreAuthors(Func<CoAuthor, bool> specification)
        {
            SqlParameter[] param = new SqlParameter[]
                    {
                        
                    };
            var statistics = srimsContext.Database.SqlQuery<CoAuthor>("dbo.spGetCoreAuthors", param)
                    .Where(specification);

            return statistics;
        }

        private IEnumerable<CoAuthor> GetCoauthors(Func<CoAuthor, bool> specification, int authorId, int limit = 1)
        {
            SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@authorId", authorId),
                        new SqlParameter("@limit", limit),
                    };
            var statistics = srimsContext.Database.SqlQuery<CoAuthor>("dbo.spGetCoauthors @authorId,@limit", param)
                    .Where(specification);

            return statistics;
        }

        private IEnumerable<Keyword> GetKeyWords(Func<Keyword, bool> specification, ref int totalCount)
        {    
            var total = new SqlParameter("@total", SqlDbType.Int);
            total.Direction = ParameterDirection.Output;

            var statistics = srimsContext.Database.SqlQuery<Keyword>("dbo.spGetKeywords @total out", total)
                    .Where(specification)
                    .ToList();

            totalCount = (int)total.Value;

            return statistics;
        }

        private IEnumerable<Keyword> GetAuthorKeyWords(Func<Keyword, bool> specification, int authorId, ref int totalCount)
        {
            var authorsId = new SqlParameter("@authorId", authorId);
            var total = new SqlParameter("@total", SqlDbType.Int);
            total.Direction = ParameterDirection.Output;

            var statistics = srimsContext.Database.SqlQuery<Keyword>("dbo.spGetAuthorKeywords @authorId,@total out", authorsId, total)
                    .Where(specification)
                    .ToList();

            totalCount = (int)total.Value;

            return statistics;
        }
    }
}
