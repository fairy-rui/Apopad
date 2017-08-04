using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using SrimsOUC.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Apopad.Network
{
    public class CoAuthorNetwork
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly SrimsContext srimsContext;

        private readonly IRepository<int, Person> personRepository;
        private readonly IRepository<int, AuthorShip> authorShipRepository;

        public CoAuthorNetwork(IRepositoryContext repositoryContext, SrimsContext srimsContext)
        {
            this.repositoryContext = repositoryContext;
            this.srimsContext = srimsContext;

            personRepository = repositoryContext.GetRepository<int, Person>();            
            authorShipRepository = repositoryContext.GetRepository<int, AuthorShip>();
        }

        public void BuildNetWork()
        {            
            var experts = srimsContext.Expert.Select(e => 
                new CoAuthor
                {
                    ExpertID = e.ID,
                    Number = e.Number,
                    Name = e.Name,
                    EnglishName = e.NameSpell,
                    Count = 0,
                }).ToList();
            foreach (var expert in experts)
            {
                BuildCoAuthorNetWork(expert);
            }
            
            repositoryContext.Commit();
        }        

        public void BuildCoAuthorNetWork(CoAuthor author)
        {
            var coAuthors = GetCoauthors(ca => true, author.ExpertID.Value, 2012, 2013).ToList();
            if(coAuthors.Count > 0 && ExistOrAddAuthorShip(author))
            {
                var authorShip = authorShipRepository.FindAll(a => a.PersonNo == author.Number).First();
                foreach (var ca in coAuthors)
                {
                    AuthorShip caShip = null;
                    if (string.IsNullOrEmpty(ca.Number))
                    {
                        caShip = new AuthorShip
                        {
                            PersonId = null,
                            PersonNo = null,
                            Name = ca.Name == "学生" ? ca.Name : "外单位人员",
                            EnglishName = normalizeName(ca.EnglishName),
                        };
                        authorShipRepository.Add(caShip);
                        repositoryContext.Commit();
                    }
                    else if (ExistOrAddAuthorShip(ca))
                    {
                        caShip = authorShipRepository.FindAll(a => a.PersonNo == ca.Number).First();                        
                    }

                    if(caShip != null)
                    {
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

        private IEnumerable<CoAuthor> GetCoauthors(Func<CoAuthor, bool> specification, int authorId, int startYear, int endYear, int limit = 0)
        {
            SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@authorId", authorId),
                        new SqlParameter("@startYear", startYear),
                        new SqlParameter("@endYear", endYear),
                        new SqlParameter("@limit", limit),
                    };
            var statistics = srimsContext.Database.SqlQuery<CoAuthor>("dbo.spGetCoauthors @authorId,@startYear,@endYear,@limit", param)
                    .Where(specification);

            return statistics;
        }

        private string normalizeName(string name)
        {
            var arr = name.Split(new char[] { ',' });
            string eName = arr[0] + "," + removeNotLetterChar(arr[1]);

            return eName;
        }

        private string removeNotLetterChar(string input)
        {
            if (null == input) return null;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
}
