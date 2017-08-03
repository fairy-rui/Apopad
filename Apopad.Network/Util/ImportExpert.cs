using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using SrimsOUC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Network.Util
{
    public interface IImportExpert
    {
        void DoImportExpert();
    }

    public class ImportExpert : IImportExpert
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly SrimsContext srimsContext;

        private readonly IRepository<int, Person> personRepository;
        private readonly IRepository<int, Domain.Model.Department> departmentRepository;

        public ImportExpert(IRepositoryContext repositoryContext, SrimsContext srimsContext)
        {
            this.repositoryContext = repositoryContext;
            this.srimsContext = srimsContext;

            personRepository = repositoryContext.GetRepository<int, Person>();
            departmentRepository = repositoryContext.GetRepository<int, Domain.Model.Department>();        
        }

        public void DoImportExpert()
        {
            var experts = srimsContext.Expert.Where(e => e.ID > 4529).ToList();
            foreach(var expert in experts)
            {
                ImportOneExpert(expert);
            }

            repositoryContext.Commit();
        }

        /// <summary>
        /// 导入一个专家信息
        /// </summary>
        /// <param name="expert"></param>
        private void ImportOneExpert(Expert expert)
        {
            var exist = personRepository.Exists(p => p.PersonNo == expert.Number && p.NameCN == expert.Name);
            if (!exist)
            {
                var person = new Person
                {
                    PersonNo = expert.Number,
                    NameCN = expert.Name,
                    NameEN = ChineseToSpell.Get(expert.Name),
                    NameENAbbr = ChineseToSpell.GetAbbr(expert.Name),
                    Sex = expert.Sex == 1 ? "male" : "female",
                    Birthday = expert.Birthday,
                    IDCard = expert.IDCardNumber,
                    Mobile = expert.MobilePhone,
                    Email = expert.Email,
                    PersonType = PersonType.EXPERT,
                };
                if(expert.CollegeID != null)
                {
                    var coll = srimsContext.Department.FirstOrDefault(d => d.ID == expert.CollegeID);
                    var dept = departmentRepository.FindAll(d => d.Name == coll.Name).FirstOrDefault();
                    var pd = new PersonDepartment
                    {
                        Person = person,
                        Department = dept,
                        ComeDate = expert.ComeDate
                    };
                    person.Departments.Add(pd);
                }
                else if(expert.DepartmentID != null)
                {
                    var coll = srimsContext.Department.FirstOrDefault(d => d.ID == expert.DepartmentID);
                    var dept = departmentRepository.FindAll(d => d.Name == coll.Name).FirstOrDefault();
                    var pd = new PersonDepartment
                    {
                        Person = person,
                        Department = dept,
                        ComeDate = expert.ComeDate
                    };
                    person.Departments.Add(pd);
                }
                if(expert.College2ID != null)
                {
                    var coll = srimsContext.Department.FirstOrDefault(d => d.ID == expert.College2ID);
                    var dept = departmentRepository.FindAll(d => d.Name == coll.Name).FirstOrDefault();
                    var pd = new PersonDepartment
                    {
                        Person = person,
                        Department = dept,
                        ComeDate = expert.ComeDate
                    };
                    person.Departments.Add(pd);
                }

                personRepository.Add(person);
                repositoryContext.Commit();
            }
        }
    }
}
