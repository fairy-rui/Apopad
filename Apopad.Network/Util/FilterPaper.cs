using Apopad.Common.Repositories;
using Apopad.Model;
using Apopad.Network.AutoMapper;
using SrimsOUC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Network.Util
{
    public interface IFilterPaper
    {
        void DoFilterPaper(List<int> years);
    }

    public class FilterPaper : IFilterPaper
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly SrimsContext srimsContext;
        private readonly PaperContext paperContext;

        private readonly IRepository<int, Domain.Model.Paper> paperRepository;

        public FilterPaper(IRepositoryContext repositoryContext, SrimsContext srimsContext, PaperContext paperContext)
        {
            this.repositoryContext = repositoryContext;
            this.srimsContext = srimsContext;
            this.paperContext = paperContext;

            paperRepository = repositoryContext.GetRepository<int, Domain.Model.Paper>();
        }

        public void DoFilterPaper(List<int> years)
        {
            var papers = srimsContext.Paper.Where(p => years.Contains(p.PublishDateYear.Value)).ToList();
            foreach (var paper in papers)
            {
                Console.WriteLine("处理论文ID：" + paper.ID);
                FilterOnePaper(paper);
                Console.WriteLine("论文ID：" + paper.ID+"处理完毕");
            }

            paperContext.SaveChanges();
        }

        private void FilterOnePaper(SrimsOUC.Data.Model.Paper paper)
        {
            var exist = paperRepository.Exists(p => p.DocumentTitle == paper.Name);
            if (exist)
            {
                var p1 = paperRepository.FindAll(p => p.DocumentTitle == paper.Name).FirstOrDefault();

                var p2 = p1.MapTo<Model.Paper>();               
                foreach(var author in p1.Authors)
                {
                    var a = author.MapTo<Model.Author>();
                    var candidates = author.Candidates.Select(c => c.MapTo<Model.Candidate>());
                    foreach(var candidate in candidates)
                    {
                        a.Candidate.Add(candidate);
                    }
                    p2.Author.Add(a);
                }

                paperContext.Paper.Add(p2);

                paperContext.SaveChanges();
            }
        }
    }
}
