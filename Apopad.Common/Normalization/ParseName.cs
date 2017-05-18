using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Apopad.Common.Normalization
{
    public class ParseName : IParseName
    {
        private NameStyle style;
        private List<string> singleFirstName;
        private List<string> multyFirstName;
        private List<Name> nameObjList;
        private string syllableReg;

        private string baseDict = System.AppDomain.CurrentDomain.BaseDirectory;

        public ParseName()
        {
            singleFirstName = new List<string>();
            multyFirstName = new List<string>();

            style = new NameStyle();

            //加载拼音音节的正则表达式
            using (StreamReader reader = new StreamReader(string.Format("{0}{1}", baseDict,
                    @"\App_Data\yinjie.txt"), Encoding.Default))
            {
                syllableReg = reader.ReadLine();
            }
            //加载汉语单姓拼音
            using (StreamReader reader = new StreamReader(string.Format("{0}{1}", baseDict,
                    @"\App_Data\single.txt"), Encoding.UTF8))
            {
                String str = null;
                while (null != (str = reader.ReadLine()))
                {
                    singleFirstName.Add(str);
                }
            }
            //加载汉语复姓拼音
            using (StreamReader reader = new StreamReader(string.Format("{0}{1}", baseDict,
                    @"\App_Data\multy.txt"), Encoding.UTF8))
            {
                String str = null;
                while (null != (str = reader.ReadLine()))
                {
                    multyFirstName.Add(str);
                }

            }
        }

        public List<Name> normalizeNames(string authors)
        {
            //作者名用；分割
            string[] nameList = authors.Split(new char[] { ';' });
            if (null == nameList)
            {
                throw new Exception("the format of authors is unilegal");
            }

            nameObjList = new List<Name>();
            style.clear();

            foreach (string name in nameList)
            {
                try
                {
                    parseSingleName(name.Trim());
                }
                catch (Exception e)
                {

                }

            }

            setNameStyle();

            return nameObjList;
        }

        private void setNameStyle()
        {
            if (style.nameAbbr > style.notNameAbbr)
                Name.isAbbr = true;
            else
                Name.isAbbr = false;

            if (nameObjList.Count <= 0) return;
            if (style.sureAsc > style.sureDesc)
            {
                Name.asc = true;
            }
            else if (style.sureAsc < style.sureDesc)
            {
                Name.asc = false;
            }
            else
            {
                if (style.asc > style.desc)
                    Name.asc = true;
                else if (style.asc < style.desc)
                    Name.asc = false;
                else
                {
                    if (style.notAsc > style.notDesc)
                    {
                        Name.asc = false;
                    }
                    else
                    {
                        Name.asc = true;
                    }
                }
            }
        }

        private void parseSingleName(string name)
        {
            int i = 0;
            string[] arr = new string[1];
            char[] split = new char[] { ',', ' ' };
            while (i < split.Length && arr.Length != 2)
            {
                arr = name.Split(new char[] { split[i] });
                i++;
            }

            Name nameObj = new Name();
            nameObjList.Add(nameObj);

            if (!isChineseName(arr))
            {
                nameObj.isEnglishName = true;
                nameObj.english = name.Trim();
                return;
            }

            nameObj.pre = removeNotLetterChar(arr[0]);
            if (arr.Length > 1)
            {
                nameObj.next = removeNotLetterChar(arr[1]);
            }
            else
            {
                nameObj.next = "";
            }

            //if (!isChineseName(nameObj)) return;

            int preFirstName = -1, nxtFirstName = -1;
            //bool firstAddr = isAbbr(nameObj.pre);
            //bool secondAbbr = isAbbr(nameObj.next);
            bool preAbbr = arr[0].Contains('.') && (arr[0].ToUpper() == arr[0]);
            bool nextAbbr = arr.Length > 1 ? arr[1].Contains('.') && (arr[1].ToUpper() == arr[1]) : false;

            if (preAbbr || nextAbbr)
                style.nameAbbr++;
            else
                style.notNameAbbr++;

            if (!preAbbr)
            {
                if (singleFirstName.Contains(nameObj.pre.ToLower()) || multyFirstName.Contains(nameObj.pre.ToLower()))
                {
                    style.asc++;
                    preFirstName = 1;
                }
                else
                {
                    style.notAsc++;
                    preFirstName = 0;
                }
            }
            if (!nextAbbr)
            {
                if (singleFirstName.Contains(nameObj.next.ToLower()) || multyFirstName.Contains(nameObj.next.ToLower()))
                {
                    style.desc++;
                    nxtFirstName = 1;
                }
                else
                {
                    style.notDesc++;
                    nxtFirstName = 0;
                }
            }
            if (preFirstName == 1 && nxtFirstName == -1)
            {
                style.sureAsc++;
            }
            if (preFirstName == -1 && nxtFirstName == 1)
            {
                style.sureDesc++;
            }
        }
        private bool isAbbr(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char c = str.ElementAt(i);
                if (!(c >= 'A' && c <= 'Z')) return false;
            }
            return true;
        }
        private String removeNotLetterChar(String input)
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

        private bool isChineseName(Name name)
        {
            bool pinyin = true;
            if (!isAbbr(name.pre))
            {
                pinyin = isChineseCharPinyin(name.pre.ToLower());
            }
            if (!isAbbr(name.next))
            {
                pinyin = pinyin && isChineseCharPinyin(name.next.ToLower());
            }
            return (pinyin);
        }
        private bool isChineseName(string[] ary)
        {
            bool pinyin = true;
            if (!ary[0].Contains('.'))
            {
                pinyin = isChineseCharPinyin(removeNotLetterChar(ary[0].ToLower()));
            }
            else
            {
                if (ary[0].ToUpper() != ary[0])
                {
                    string[] lary = ary[0].ToLower().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lary.Length; i++)
                    {
                        if (lary[i].Contains('.')) continue;
                        pinyin = pinyin && isChineseCharPinyin(removeNotLetterChar(lary[i]));
                    }
                }
            }
            if (ary.Length > 1)
            {
                if (!ary[1].Contains('.'))
                {
                    pinyin = pinyin && isChineseCharPinyin(removeNotLetterChar(ary[1].ToLower()));
                }
                else
                {
                    if (ary[1].ToUpper() != ary[1])
                    {
                        string[] lary = ary[1].ToLower().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < lary.Length; i++)
                        {
                            if (lary[i].Contains('.')) continue;
                            pinyin = pinyin && isChineseCharPinyin(removeNotLetterChar(lary[i]));
                        }
                    }
                }
            }

            return (pinyin);
        }
        private bool isChineseCharPinyin(String pinyin)
        {
            String input = pinyin.ToLower();
            try
            {
                Regex reg = new Regex(syllableReg);
                bool match = reg.IsMatch(input);
                if (!match)
                {
                    //Log.Warn("not chinese name: " + input);
                    Console.Write("not china: ");
                    Console.WriteLine(input);
                }
                return match;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
