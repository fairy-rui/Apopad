using Apopad.Common.Normalization;
using Apopad.Common.Repositories;
using Apopad.Common.Search;
using Apopad.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apopad.Domain.Service
{
    public class PretreatmentService : IPretreatmentService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly IRepository<int, Paper> paperRepository;
        private readonly IRepository<int, Department> deptRepository;
        private readonly IRepository<int, DepartmentAlias> aliasRepository;

        private readonly IParseName parseName;
        private readonly IAnalyser analyser;
        private readonly IFilter filter;

        private static string OurUnitName = "中国海洋大学";
        private static List<Department> depList = null;
        private static List<DepartmentAlias> aliasList = null;
        private static List<DepartmentAlias> ourAlias = null;

        public PretreatmentService(IRepositoryContext repositoryContext, 
            IParseName parseName, IAnalyser analyser, IFilter filter)
        {
            this.repositoryContext = repositoryContext;
            this.parseName = parseName;
            this.analyser = analyser;
            this.filter = filter;

            paperRepository = repositoryContext.GetRepository<int, Paper>();
            deptRepository = repositoryContext.GetRepository<int, Department>();
            aliasRepository = repositoryContext.GetRepository<int, DepartmentAlias>();

            Initialize();
        }

        public void Initialize()
        {
            depList = deptRepository.FindAll().ToList();
            aliasList = aliasRepository.FindAll().ToList();
            int OUCId = depList.Where(e => e.Name == OurUnitName).First().Id;
            ourAlias = aliasList.Where(e => e.DepartmentId == OUCId).ToList();
            aliasList = aliasList.Except(ourAlias).ToList();
        }

        /// <summary>
        /// 对论文作者等信息进行预处理
        /// </summary>
        public void pretreatPaper()
        {
            var pList = paperRepository.FindAll(p => p.Status == PaperStatus.PRETREATMENT).ToList();

            foreach(var paper in pList)
            {
                var authors = getAuthors(paper);
                foreach(var author in authors)
                {
                    paper.Authors.Add(author);
                }
                paper.Status = PaperStatus.LOOKUP;

                paperRepository.Update(paper);

                repositoryContext.Commit();
            }

            repositoryContext.Commit();
        }

        /// <summary>
        /// 获得每篇论文的作者相关信息，包括英文名字、院系、是否通信作者等信息
        /// </summary>
        /// <param name="paper">一篇论文</param>
        /// <returns>作者列表</returns>
        public List<Author> getAuthors(Paper paper)
        {
            string[] authorAbbr = paper.getAuthorAbbrName(); //作者名字简拼数组
            string[] authorFull = paper.getAuthorOriginalName(); //作者名字全拼数组
            string[] authorAry = paper.extractAuthorFromAddress();    //从作者地址中提取出的作者数组
            string[] addrLine = paper.extractAuthorAddress();    //作者地址中的每条地址信息
            string connAuthor = paper.extractReprintAuthor(); //通行作者英文名字
            int userOrdinal = 0;    //作者在作者地址列表中所署名的本校位次
            List<Author> authorList = new List<Author>();
            Author author = null;
            List<string> userDept = null;   //每个作者的单位List
            Name name = null;
            
            //解析作者名字，检测是否是简拼、倒序
            var names = parseName.normalizeNames(paper.AuthorFullName);

            //对每个作者进行预处理，生成model
            for (int i = 0; i < authorFull.Count(); i++)
            {
                name = names[i];
                userOrdinal = getUnitOrdinal(authorFull[i], authorAry, addrLine);
                userDept = getDepartment(authorFull[i], authorAry, addrLine);

                if (paper.DepartmentId == null && userDept.Count > 0)
                {
                    paper.DepartmentId = getPaperDepartmentId(userDept);
                }

                author = new Author
                {
                    PaperId = paper.Id,
                    Ordinal = i + 1,
                    DepartmentName = string.Join(";", userDept),
                    IsCorrespondingAuthor = authorAbbr[i].Trim() == connAuthor,
                    PublishDate = paper.PublicationDate,
                    IsOtherUnit = userOrdinal > 0 ? false : true,
                    SignOrdinal = userOrdinal,
                };

                if (Name.isAbbr)
                {
                    author.NameENAbbr = name.ToString();
                }
                else
                {
                    author.NameEN = name.ToString();
                }

                authorList.Add(author);
            }

            return authorList;
        }

        /// <summary>
        /// 判断给出的单位地址是否是本单位
        /// </summary>
        /// <param name="addrLine">一条地址</param>
        /// <returns>true or false</returns>
        private bool isOurUnit(string addrLine)
        {
            foreach(var name in ourAlias)
            {
                if(addrLine.Contains(name.Alias.Replace(" ", "")))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取该条地址包含的院系、实验室的别名
        /// </summary>
        /// <param name="addrLine">一条地址</param>
        /// <returns>院系别名的列表</returns>
        private List<string> getContainsAlias(string addrLine)
        {
            List<string> list = new List<string>();
            HashSet<int> deptId = new HashSet<int>();
            var ary = addrLine.Split(',').Select(t => t.Trim()).ToArray();

            foreach (var address in ary)
            {
                var deptList = Search(address, 1, 0.6);
                if (deptList.Count() > 0)
                {
                    var dept = deptList.First();
                    if (!deptId.Contains(dept.DepartmentId))
                    {
                        list.Add(dept.Alias);
                        deptId.Add(dept.DepartmentId);
                    }
                }
            }

            return list;
        }
        ////提取作者署名单位没有采用模糊匹配
        //private List<string> getContainsAlias(string addrLine)
        //{
        //    List<string> list = new List<string>();
        //    HashSet<int> deptId = new HashSet<int>();
        //    foreach (var alias in aliasList)
        //    {
        //        if (addrLine.Contains(alias.Alias.Replace(" ", "")))
        //        {
        //            if (!deptId.Contains(alias.DepartmentId))
        //            {
        //                list.Add(alias.Alias);
        //                deptId.Add(alias.DepartmentId);
        //            }
        //        }
        //    }

        //    return list;
        //}


        /// <summary>
        /// 获取某位作者在作者地址列表中所署名的本校位次
        /// </summary>
        /// <param name="name">一个作者英文名字</param>
        /// <param name="authors">从作者地址中提取出的作者list</param>
        /// <param name="address">地址list</param>
        /// <returns>0：外单位 >0：本校署名位次</returns>
        private int getUnitOrdinal(string name, string[] authors, string[] address)
        {
            int index = 0;

            //去提取出的作者数组中进行匹配
            for (int i = 0; i < authors.Count(); i++)
            {
                string[] nameSpell = authors[i].Split(';').Select(s => s.Trim()).ToArray();
                if (nameSpell.Where(s => s == name).Count() > 0)  //该行匹配成功
                {
                    index++;
                    //找到该作者的学校或单位
                    string addr = address[i].Replace(" ", "").ToLower();
                    if (isOurUnit(addr))
                    {
                        return index;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 获取某个作者在地址列表中署名的院系、实验室的英文名字
        /// </summary>
        /// <param name="name">作者英文名字</param>
        /// <param name="authors">从作者地址中提取出的作者list</param>
        /// <param name="address">地址list</param>
        /// <returns>院系list</returns>
        private List<string> getDepartment(string name, string[] authors, string[] address)
        {
            List<string> dept = new List<string>();
            List<string> list = null;

            //去提取出的作者数组中进行匹配
            for (int i = 0; i < authors.Count(); i++)
            {
                string[] nameSpell = authors[i].Split(';').Select(s => s.Trim()).ToArray();
                if (nameSpell.Where(s => s == name).Count() > 0)  //该行匹配成功
                {
                    //找到该作者的学校或单位
                    string addr = address[i].Replace(" ", "").ToLower();
                    if (isOurUnit(addr))
                    {
                        list = getContainsAlias(address[i].ToLower());
                        //list = getContainsAlias(addr);
                        if (list.Count() > 0)
                        {
                            dept.AddRange(list);
                        }
                    }
                }
            }

            //Lambda表达式去重，保留重复元素的第一个
            dept = dept.Where((d, i) => dept.FindIndex(p => p == d) == i).ToList();

            return dept;
        }

        /// <summary>
        /// 获得论文所属学院
        /// </summary>
        /// <param name="depts">院系英文名字list</param>
        /// <returns>学院ID</returns>
        public int getPaperDepartmentId(List<string> depts)
        {
            DepartmentAlias dAlias = null;
            Department department = null;

            foreach (string dept in depts)
            {
                dAlias = aliasList.Where(e => e.Alias == dept).First();
                department = depList.Where(e => e.Id == dAlias.DepartmentId).First();

                while (department.Type != DepartmentType.COLLEGE && department.ParentId != null)
                {
                    department = depList.Where(e => e.Id == department.ParentId).First();
                }

                if (department.Type == DepartmentType.COLLEGE)
                {
                    return department.Id;
                }
            }

            return department.Id;
        }

        public List<DepartmentAlias> Search(string s, int number = 1, double threshold = 0.7)
        {
            if (string.IsNullOrWhiteSpace(s))
                return new List<DepartmentAlias>();

            int s_length = s.Length;
            int upper = (int)Math.Ceiling(s_length * (1.0 - threshold) * 1);

            var s_ary = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var filter_str = (from item in aliasList.AsParallel()
                              where filter.filter_str(s, item.Alias, upper, s_ary, item.Alias.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray())
                              select item)
                              .ToArray();

            var q = (from item in filter_str.AsParallel()
                     let sim = analyser.GetLikenessValue(s, item.Alias)
                     where sim >= threshold
                     orderby sim descending, item.Alias
                     select item
                    ).Take(number);

            return q.ToList();
        }
    }
}
