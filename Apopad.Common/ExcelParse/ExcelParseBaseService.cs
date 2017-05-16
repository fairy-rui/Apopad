using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace Apopad.Common.ExcelParse
{
    public abstract class ExcelParseBaseService : IExcelParseBaseService
    {
        public bool CheckDataType(string cellType, string cellValue)
        {
            try
            {
                Type type = Type.GetType(cellType, true, true);
                Convert.ChangeType(cellValue, type);    //将cellValue转换为指定类型的对象，以此判断是否为指定类型对象的值
                //MethodInfo mi = cellValue.GetType().GetMethod("Parse").MakeGenericMethod(type);
                //mi.Invoke(cellValue, null);
                
                return true;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }
            catch (FormatException ex)
            {
                return false;
            }
            catch (OverflowException ex)
            {
                return false;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }

        public bool CheckNull(string cellValue, ref int nullcount)
        {
            if (string.IsNullOrEmpty(cellValue))
            {
                nullcount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取cell的数据，并设置为对应的数据类型
        /// </summary>
        /// <param name="cell">excel单元格</param>
        /// <returns>返回相应的数据类型</returns>
        public object GetCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell.CellType != CellType.Blank)
                {
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            // Date Type的数据CellType是Numeric
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;
                            }
                            else
                            {
                                // Numeric type
                                value = cell.NumericCellValue;
                            }
                            break;
                        case CellType.Boolean:
                            // Boolean type
                            value = cell.BooleanCellValue;
                            break;
                        default:
                            // String type
                            value = cell.StringCellValue;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                value = "";
            }

            return value;
        }

        // 去除空值
        public void ReplaceSpace(ref string cellValue)
        {
            //cellValue = TruncateString(cellValue, new char[] { ' ' }, new char[] { '　' });
            //去除中文字符之间的空格
            cellValue = Regex.Replace(cellValue, @"(?<=[\u4e00-\u9fa5])(\s+)(?=[\u4e00-\u9fa5])", string.Empty);
        }

        // 对字符串做空格剔除处理
        private string TruncateString(string originalWord, char[] spiltWord1, char[] spiltWord2)
        {
            var result = "";
            var valueReplaceDbcCase = originalWord.Split(spiltWord1);

            if (valueReplaceDbcCase.Count() > 1)
            {
                for (int i = 0; i < valueReplaceDbcCase.Count(); i++)
                {
                    if (valueReplaceDbcCase[i] != "" && valueReplaceDbcCase[i] != " " &&
                        valueReplaceDbcCase[i] != "　")
                    {
                        result += TruncateString(valueReplaceDbcCase[i], spiltWord2, new char[0]);
                    }
                }
            }
            else
            {
                if (spiltWord2.Any())
                {
                    result = TruncateString(originalWord, spiltWord2, new char[0]);
                }
                else
                {
                    result = originalWord;
                }
            }

            return result;
        }

        // 判断单元格是否被合并
        public bool IsMergedRegionCell(int cellIndex, int rowIndex, ISheet sheet, ref CellRangeAddress regionAddress)
        {
            bool isMerged = false;
            var regionLists = GetMergedCellRegion(sheet);

            foreach (var cellRangeAddress in regionLists)
            {
                for (int i = cellRangeAddress.FirstRow; i <= cellRangeAddress.LastRow; i++)
                {
                    if (rowIndex == i)
                    {
                        for (int j = cellRangeAddress.FirstColumn; j <= cellRangeAddress.LastColumn; j++)
                        {
                            if (cellIndex == j)
                            {
                                isMerged = true;
                                regionAddress = cellRangeAddress;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return isMerged;
        }

        // 获取合并区域信息
        private List<CellRangeAddress> GetMergedCellRegion(ISheet sheet)
        {
            int mergedRegionCellCount = sheet.NumMergedRegions;
            var returnList = new List<CellRangeAddress>();

            for (int i = 0; i < mergedRegionCellCount; i++)
            {
                returnList.Add(sheet.GetMergedRegion(i));
            }

            return returnList;
        }

        // 读取XML配置信息集
        public List<Regular> GetXMLInfo(string xmlpath)
        {
            var reader = new XmlTextReader(xmlpath);
            var doc = new XmlDocument();
            doc.Load(reader);

            var headerList = new List<Regular>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var header = new Regular();

                if (node.Attributes["firstHeaderRow"] != null)
                    header.HeaderRegular.Add("firstHeaderRow", int.Parse(node.Attributes["firstHeaderRow"].Value));
                if (node.Attributes["lastHeaderRow"] != null)
                    header.HeaderRegular.Add("lastHeaderRow", int.Parse(node.Attributes["lastHeaderRow"].Value));
                if (node.Attributes["sheetCount"] != null)
                    header.HeaderRegular.Add("sheetCount", int.Parse(node.Attributes["sheetCount"].Value));
                if (node.Attributes["matrixHeaderStartCol"] != null)
                    header.HeaderRegular.Add("matrixHeaderStartCol", int.Parse(node.Attributes["matrixHeaderStartCol"].Value));
                if (node.Attributes["matrixHeaderEndCol"] != null)
                    header.HeaderRegular.Add("matrixHeaderEndCol", int.Parse(node.Attributes["matrixHeaderEndCol"].Value));

                if (node.Attributes["headerText"] != null)
                    header.HeaderText = node.Attributes["headerText"].Value;
                if (node.Attributes["propertyName"] != null)
                    header.PropertyName = node.Attributes["propertyName"].Value;
                if (node.Attributes["dataType"] != null)
                    header.DataType = node.Attributes["dataType"].Value;

                headerList.Add(header);
            }
            return headerList;
        }
    }
}
