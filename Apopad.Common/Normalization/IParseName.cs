using System.Collections.Generic;

namespace Apopad.Common.Normalization
{
    public interface IParseName
    {
        List<Name> normalizeNames(string authors);
    }

    /// <summary>
    /// 识别论文作者的名和姓
    /// </summary>
    public class NameStyle
    {
        /// <summary>
        /// 名字是正序的
        /// </summary>
        public int asc;
        /// <summary>
        /// 不是正序的
        /// </summary>
        public int notAsc;
        /// <summary>
        /// 名字是反序的
        /// </summary>
        public int desc;
        /// <summary>
        /// 名字不是反序的
        /// </summary>
        public int notDesc;

        /// <summary>
        /// 确定是正序的
        /// </summary>
        public int sureAsc;
        /// <summary>
        /// 确定是反序的
        /// </summary>
        public int sureDesc;

        /// <summary>
        /// 名字是缩写
        /// </summary>
        public int nameAbbr;
        /// <summary>
        /// 名字不是缩写
        /// </summary>
        public int notNameAbbr;

        public void clear()
        {

            asc = -1;
            notAsc = -1;
            desc = -1;
            notDesc = -1;
            sureAsc = 0;
            sureDesc = 0;

            nameAbbr = 0;
            notNameAbbr = 0;
        }
    }
    public class Name
    {
        public string pre;
        public string next;
        public string english;
        public bool isEnglishName;

        public static bool asc;
        public static bool isAbbr;

        public override string ToString()
        {
            if (isEnglishName) return english;
            if (asc)
            {
                if (isAbbr) return string.Format("{0}, {1}", pre, next);
                else return string.Format("{0}{1}", pre, next);
            }
            else
            {
                if (isAbbr) return string.Format("{0}, {1}", next, pre);
                else return string.Format("{0}{1}", next, pre);
            }
        }
    }
}
