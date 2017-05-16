using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Domain.Service
{
    public class LookUpService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly IRepository<int, Paper> paperRepository;
        private readonly IRepository<int, Person> personRepository;
        private readonly IRepository<int, Department> deptRepository;
        private readonly IRepository<int, DepartmentAlias> aliasRepository;

        public LookUpService(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;

            paperRepository = repositoryContext.GetRepository<int, Paper>();
            personRepository = repositoryContext.GetRepository<int, Person>();
            deptRepository = repositoryContext.GetRepository<int, Department>();
            aliasRepository = repositoryContext.GetRepository<int, DepartmentAlias>();
        }

        /// <summary>
        /// 从学校范围内查找作者候选人
        /// </summary>
        /// <param name="author">需要查找候选人的作者对象</param>
        /// <returns>找到的候选人的集合</returns>
        public List<Person> GetPersonFromShool(Author author)
        {
            var pList = personRepository.FindAll(p => p.NameEN.ToLower().StartsWith(author.NameEN.ToLower()) ||
                        p.NameENAbbr.ToLower().StartsWith(author.NameENAbbr.ToLower()))
                        .ToList();
            return pList;
        }
        /// <summary>
        /// 在院系范围内查找作者候选人
        /// </summary>
        /// <param name="author">需要查找候选人的作者对象</param>
        /// <returns>找到的候选人列表</returns>
        public List<Person> GetPersonFromDepart(Author author)
        {
            var pList = repositoryContext.SqlQuery<Person>("dbo.spLookUpCandidate @authorId", author.Id)
                        .ToList();

            return pList;
        }
    }
}
