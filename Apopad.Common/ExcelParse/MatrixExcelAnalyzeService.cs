using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Apopad.Common.ExcelParse
{
    public class MatrixExcelAnalyzeService : ExcelAnalyzeService
    {
        public new Dictionary<int, string> GetExcelHeaders(ISheet sheet, ref UploadExcelFileResult uploadExcelFileResult,
            List<Regular> list)
        {
            int firstHeaderRowIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["firstHeaderRow"];
            int lastHeaderRowIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["lastHeaderRow"];
            
            var dict = new Dictionary<int, string>();

            try
            {
                // 循环获得表头
                for (int i = firstHeaderRowIndex - 1; i < lastHeaderRowIndex; i++)
                {
                    IRow headerRow = sheet.GetRow(i);
                    int cellCount = headerRow.LastCellNum;

                    for (int j = headerRow.FirstCellNum; j < cellCount; j++)
                    {
                        string value = headerRow.GetCell(j).StringCellValue.Trim();
                        if (!string.IsNullOrEmpty(value))
                        {
                            // 根据 键－值 是否已存在做不同处理
                            //TODO 代码待重构！！！
                            try
                            {
                                string oldValue = dict[j];
                                dict.Remove(j);
                                dict.Add(j, oldValue + "-" + value);
                            }
                            catch (Exception)
                            {
                                dict.Add(j, value);
                            }
                        }
                        else
                        {
                            CellRangeAddress regionAddress = null;
                            if (IsMergedRegionCell(j, i, sheet, ref regionAddress))  //2、单元格为合并单元格且不在合并区域左上角
                            {
                                if (regionAddress.FirstRow >= (firstHeaderRowIndex - 1) && i == regionAddress.FirstRow)//合并单元格，i == regionAddress.FirstRow则为列合并
                                {
                                    if (dict.Keys.Contains(regionAddress.FirstColumn))
                                    {
                                        dict.Add(j, dict[regionAddress.FirstColumn]);
                                    }
                                }
                            }
                        }
                    }
                }
                // 遍历表头字典，消除空格
                for (int i = 0; i < dict.Count; i++)
                {
                    var value = dict[i];
                    this.ReplaceSpace(ref value);
                    dict[i] = value;
                } 
            }
            catch (Exception e)
            {
                uploadExcelFileResult.Success = false;
                uploadExcelFileResult.Message = "读取EXCEL表头模板时发生错误，可能造成原因是：EXCEL模板被修改！请下载最新EXCEL模板！";
            }

            return dict;
        }

        public new List<TableDTO> GetExcelDatas<TableDTO>(ISheet sheet, string sheetName, List<Regular> list,
            Dictionary<int, string> dict, int rowCount)
        {
            // 返回数据对象集合
            var resultList = new List<TableDTO>();
            // 表头结束行
            int lastHeaderRowIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["lastHeaderRow"];
            int matrixHeaderEndColIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["matrixHeaderEndCol"];

            // 循环行数据
            for (int i = lastHeaderRowIndex; i <= rowCount; i++)
            {
                // 记录该行空值数
                int nullcount = 0;

                IRow dataRow = sheet.GetRow(i);
                int cellCount = dict.Count;

                if (dataRow != null)
                {
                    // 循环列数据
                    for (int j = matrixHeaderEndColIndex; j < cellCount; j++)
                    { 
                        // 产生一个新的泛型对象
                        var model = Activator.CreateInstance<TableDTO>();
                        // 获取第i行第一列值
                        string rowItem = dataRow.GetCell(0).ToString();
                        if (rowItem == "")
                        {
                            break;
                        }
                        //添加Y轴值到DTO对象
                        Regular YHeader = list.Find(h => h.HeaderText == "Y轴");
                        string YProperty = YHeader.PropertyName;
                        PropertyInfo YProp = model.GetType().GetProperty(YProperty);
                        YProp.SetValue(model, rowItem, null);


                        //添加X轴值到DTO对象
                        Regular XHeader = list.Find(h => h.HeaderText == "X轴");
                        string XProperty = XHeader.PropertyName;
                        PropertyInfo XProp = model.GetType().GetProperty(XProperty);
                        XProp.SetValue(model, dict[j], null);


                        string value = "";
                        Regular header = list.Find(h => h.HeaderText == "值");
                        string property = header.PropertyName;
                        PropertyInfo prop = model.GetType().GetProperty(property);
                        
                        switch (dataRow.GetCell(j).CellType)
                        {
                            case CellType.Formula:
                                value = dataRow.GetCell(j).StringCellValue.ToString();
                                break;
                            default:
                                value = dataRow.GetCell(j).ToString();
                                break;
                        }

                        // 去除空值
                        this.ReplaceSpace(ref value);

                        if (value == "")
                        {
                            CellRangeAddress regionAddress = null;
                            if (IsMergedRegionCell(j, i, sheet, ref regionAddress))  //2、单元格为合并单元格且不在合并区域左上角
                            {
                                if (regionAddress.FirstRow >= lastHeaderRowIndex && i != regionAddress.FirstRow)//合并单元格，行合并，若i == regionAddress.FirstRow则为列合并
                                {
                                    int resultIndex = regionAddress.FirstRow - lastHeaderRowIndex;

                                    var oldModel =
                                        resultList.Select((p, d) => new { p, d })
                                            .Where(p => p.d == resultIndex)
                                            .Select(p => p.p).First();
                                    var regionValue = oldModel.GetType().GetProperty(header.PropertyName).GetValue(oldModel, null);//获得合并单元格第一行数据
                                    value = regionValue.ToString();
                                }
                                else    //列合并
                                {
                                    Regular regionReader = list.Find(h => h.HeaderText == dict[regionAddress.FirstColumn]);
                                    var regionValue = model.GetType().GetProperty(regionReader.PropertyName).GetValue(model, null);
                                    value = regionValue.ToString();
                                }
                            }
                            else   //1、单元格空值
                            {
                                nullcount++;
                            }
                        }

                        // 赋值
                        switch (header.DataType)
                        {
                            case "System.double":
                                double valueDecimal;
                                if (double.TryParse(value, out valueDecimal))
                                {
                                    prop.SetValue(model, valueDecimal, null);
                                }
                                break;
                            case "System.Int16":
                                short valueInt16;
                                if (Int16.TryParse(value, out valueInt16))
                                {
                                    prop.SetValue(model, valueInt16, null);
                                }
                                break;
                            case "System.Int32":
                                int valueInt32;
                                if (Int32.TryParse(value, out valueInt32))
                                {
                                    prop.SetValue(model, valueInt32, null);
                                }
                                break;
                            case "System.Boolean":
                                bool valueBoolean;
                                if (Boolean.TryParse(value, out valueBoolean))
                                {
                                    prop.SetValue(model, valueBoolean, null);
                                }
                                break;
                            case "System.DateTime":
                                DateTime valueDateTime;
                                if (DateTime.TryParse(value, out valueDateTime))
                                {
                                    prop.SetValue(model, valueDateTime, null);
                                }
                                break;
                            default:
                                prop.SetValue(model, value, null);
                                break;
                        }

                        resultList.Add(model);
                    }
                } 
            }

            return resultList;
        }
    }
}
