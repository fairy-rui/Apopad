﻿using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// 查找论文的作者对应的人员
        /// </summary>
        public void LookupPaperAuthors()
        {

            var papers = paperRepository.FindAll(p => p.Status == PaperStatus.LOOKUP)
                        .ToList();
            foreach(var paper in papers)
            {
                paper.Authors.ToList().ForEach(
                    a => a.HasCandidate = LookUpCandidate(a));
                paper.Status = PaperStatus.CONFIRM;
            }

            repositoryContext.Commit();
        }

        /// <summary>
        /// 查找一个作者的候选人
        /// </summary>
        /// <param name="author">需要查找候选人的作者对象</param>
        /// <returns>是否找到了候选人，找到为true，没找到为false</returns>
        public bool LookUpCandidate(Author author)
        {
            //如果是外单位人员
            if (author.IsOtherUnit)
            {
                Candidate candidate = new Candidate()
                {
                    AuthorId = author.Id,
                    Name = "外单位人员",
                    Status = CandidateStatus.RIGHT,
                    Operator = "system",
                };
                author.Candidates.Add(candidate);
                return true;
            }

            var pList = new List<Person>();

            //从部门及部门的下属部门搜索
            if (!string.IsNullOrEmpty(author.DepartmentName))
            {
                pList = GetPersonFromDept(author);
            }
            //从全校范围搜索，结束
            if(pList.Count == 0)
            {
                pList = GetPersonFromShool(author);
            }

            //如果未找到此人
            if (pList.Count == 0)
            {
                return false;
            }

            //将年份不符合的记录删除
            if (pList.Count > 1)
            {
                pList = FilterByPublishYear(author.Paper, pList);
            }
            //根据导师筛选
            if (pList.Count > 1)
            {
                pList = FilterByTutor(author.Paper, pList);
            }
            //删除同一个人的重复记录，和删除年份的顺序不能颠倒
            if (pList.Count > 1)
            {
                pList = removeSamePerson(pList);
            }

            //如果只找到一个人或者多个人，将状态设置为待审核，操作者为system, Author的hasCandidate=true
            foreach (var person in pList)
            {
                Candidate candidate = new Candidate()
                {
                    AuthorId = author.Id,
                    PersonNo = person.PersonNo,
                    Name = person.NameCN,
                    Operator = "system",
                    PersonId = person.Id,
                    Status = pList.Count == 1 ? CandidateStatus.RIGHT : CandidateStatus.CHECK,

                };

                author.Candidates.Add(candidate);
            }
            return true;
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
        public List<Person> GetPersonFromDept(Author author)
        {
            var pList = repositoryContext.SqlQuery<Person>("dbo.spLookUpCandidate @authorId", author.Id)
                        .ToList();

            return pList;
        }

        private List<Person> FilterByPublishYear(Paper paper, List<Person> people)
        {
            int publishYear = -1;
            if (paper.Year.HasValue) publishYear = paper.Year.Value;
            if (publishYear < 0 && paper.PublishDate.HasValue) publishYear = paper.PublishDate.Value.Year;
            if (publishYear < 0) return people;

            List<Person> pList = new List<Person>();
            for(int i = 0; i < people.Count; i++)
            {
                var person = people.ElementAt(i);
                if(IsTimeRight(publishYear, person))
                {
                    pList.Add(person);
                }
            }
            return pList;
        }

        private List<Person> FilterByTutor(Paper paper, List<Person> people)
        {
            int index = -1;
            for(int i = 0; i < people.Count && index < 0; i++)
            {
                var person = people.ElementAt(i);
                if (string.IsNullOrEmpty(person.Tutor)) continue;
                var tutor = personRepository.FindAll(p => p.NameCN == person.Tutor
                            && p.PersonType == PersonType.EXPERT).FirstOrDefault();
                if (tutor == null) continue;
                foreach(var author in paper.Authors)
                {
                    if(string.Equals(tutor.NameEN, author.NameEN, StringComparison.OrdinalIgnoreCase)
                       || string.Equals(tutor.NameENAbbr, author.NameENAbbr, StringComparison.OrdinalIgnoreCase))
                    {
                        index = i;
                        break;
                    }
                }
            }
            if(index >= 0)
            {
                var person = people.ElementAt(index);
                people.Clear();
                people.Add(person);
            }
            return people;
        }

        private List<Person> removeSamePerson(List<Person> people)
        {
            for (int i = 0; i < people.Count - 1; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    bool same = isSamePerson(people[i], people[j]);
                    if (same)
                    {
                        int saveIndex = savePersonIndex(people, i, j);
                        if (saveIndex == j)
                        {
                            people[i] = people[j];
                        }
                        people.RemoveAt(j);
                        j--;
                    }
                }
            }
            return people;
        }

        private bool IsTimeRight(int publishYear, Person person)
        {
            int comeYear = 1924, leaveYear = 3000;
            for(int i = 0; i < person.Departments.Count; i++)
            {
                var pd = person.Departments.ElementAt(i);
                if (pd.ComeDate.HasValue)
                {
                    comeYear = pd.ComeDate.Value.Year;
                }
                if (pd.LeaveDate.HasValue)
                {
                    leaveYear = pd.LeaveDate.Value.Year;
                }
                if (publishYear > comeYear && publishYear < leaveYear + 3) return true;
            }
            return false;
        }

        private int savePersonIndex(List<Person> people, int i, int j)
        {
            var p1 = people.ElementAt(i);
            var p2 = people.ElementAt(j);
            //如果一条是老师，一条是学生保留老师的
            if (p1.PersonType != p2.PersonType)
            {
                return (p1.PersonType == PersonType.EXPERT ? i : j);
            }
            else
            {
                //如果两条都是学生或老师，保留时间最晚的那一条
                DateTime lastDate1 = GetLastComeDate(p1);
                DateTime lastDate2 = GetLastComeDate(p2);
                int c = lastDate1.CompareTo(lastDate2);
                if (c > 0) return i;
                if (c < 0) return j;
                if (p1.PersonNo.Length < p2.PersonNo.Length) return i;
                if (p1.PersonNo.Length > p2.PersonNo.Length) return j;
                return j;
            }

        }

        private DateTime GetLastComeDate(Person person)
        {
            DateTime date = new DateTime(1924, 10, 25);
            for (int i = 0; i < person.Departments.Count; i++)
            {
                var come = person.Departments.ElementAt(i).ComeDate;
                if (come.HasValue)
                {
                    int c = date.CompareTo(come);
                    if (c < 0) date = come.Value;
                }

            }
            return date;
        }

        private bool isSamePerson(Person p1, Person p2)
        {
            if (p1.PersonNo == p2.PersonNo) return true;
            if (string.Equals(p1.IDCard, p2.IDCard, StringComparison.OrdinalIgnoreCase)) return true;
            return (p1.NameCN.Trim().Equals(p2.NameCN.Trim()) && p1.Birthday.Equals(p2.Birthday));
        }
    }
}
