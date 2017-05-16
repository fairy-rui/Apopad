using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using NPOI.SS.Util;

namespace Apopad.Common.ExcelParse
{
    public abstract class ExcelAnalyzeService : ExcelParseBaseService, IExcelAnalyzeService
    {
        public int GetExcelEdition(string fileName)
        {
            var edition = 0;
            string[] items = fileName.Split(new char[] { '.' });
            int count = items.Length;
            switch (items[count - 1])
            {
                case "xls":
                    edition = 3;
                    break;
                case "xlsx":
                    edition = 7;
                    break;
                default:
                    break;
            }

            return edition;
        }

        public IWorkbook CreateWorkBook(int edition, Stream excelFileStream)
        {
            switch (edition)
            {
                case 7:
                    return new XSSFWorkbook(excelFileStream);
                case 3:
                    return new HSSFWorkbook(excelFileStream);
                default:
                    return null;
            }
        }

        public Dictionary<int, string> GetExcelHeaders(ISheet sheet, ref UploadExcelFileResult uploadExcelFileResult,
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
                // 检查表头模板是否被修改，解析矩阵类模板时将该段代码注释掉
                for (int count = 0; count < dict.Count; count++)
                {
                    Regular header = list.Find(h => h.HeaderText == dict[count]);

                    if (header == null)
                    {
                        uploadExcelFileResult.Success = false;
                        uploadExcelFileResult.Message = "读取EXCEL表头模板时发生错误，可能造成原因是：EXCEL模板被修改！请下载最新EXCEL模板！";
                    }
                }
            }
            catch (Exception e)
            {
                uploadExcelFileResult.Success = false;
                uploadExcelFileResult.Message = "读取EXCEL表头模板时发生错误，可能造成原因是：EXCEL模板被修改！请下载最新EXCEL模板！";
            }

            return dict;
        }

        public List<TableDTO> GetExcelDatas<TableDTO>(ISheet sheet, string sheetName, List<Regular> list,
            Dictionary<int, string> dict, int rowCount)
        {
            // 返回数据对象集合
            var resultList = new List<TableDTO>();
            // 表头结束行
            int lastHeaderRowIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["lastHeaderRow"];

            // 循环行数据
            for (int i = lastHeaderRowIndex; i <= rowCount; i++)
            {
                // 产生一个新的泛型对象
                var model = Activator.CreateInstance<TableDTO>();
                // 记录该行空值数
                int nullcount = 0;

                IRow dataRow = sheet.GetRow(i);
                int cellCount = dict.Count;

                if (dataRow != null)
                {
                    // 循环列数据
                    for (int j = dataRow.FirstCellNum; j < cellCount; j++)
                    {
                        string value = "";
                       
                        Regular header = list.Find(h => h.HeaderText == dict[j]);
                        PropertyInfo prop = model.GetType().GetProperty(header.PropertyName);
                        /*
                        switch (dataRow.GetCell(j).CellType)
                        {
                            case CellType.Formula:
                                value = dataRow.GetCell(j).StringCellValue.ToString();
                                break;
                            default:
                                value = dataRow.GetCell(j).ToString();
                                break;
                        }*/
                        if (dataRow.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                        {
                            ICell cell = dataRow.GetCell(j);
                            value = GetCellValue(cell).ToString();
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
                    }
                }

                // 添加非空行数据到DTO
                if (nullcount < cellCount)
                {
                    resultList.Add(model);
                }
            }

            return resultList;
        }

        public UploadExcelFileResult CheckExcelDatasEnableNull(ISheet sheet, List<Regular> list, Dictionary<int, string> dict, int rowCount)
        {
            var result = new UploadExcelFileResult();
            result.Success = true;

            // 记录单个sheet所有错误信息
            var sheetErrors = new List<ExcelFileErrorPosition>();
            // 表头结束行
            int lastHeaderRowIndex = list.Find(e => e.HeaderRegular != null).HeaderRegular["lastHeaderRow"];

            // 循环行数据
            for (int i = lastHeaderRowIndex; i <= rowCount; i++)
            {
                // 标注该行是否出错
                bool isrowfalse = false;
                // 记录该行数据临时对象
                var rowDatas = new List<string>();
                // 记录该行错误列
                var rowErrorCell = new List<int>();
                // 记录该行错误列具体错误信息
                var rowErrorMessages = new List<string>();
                // 记录该行空值数
                int nullcount = 0;


                IRow dataRow = sheet.GetRow(i);
                if (dataRow == null) continue; //没有数据的行默认是null
                int cellCount = dict.Count;

                // 循环列数据
                for (int j = dataRow.FirstCellNum; j < cellCount; j++)
                {
                    string value = "";
                    Regular header = list.Find(h => h.HeaderText == dict[j]);
                    /*
                    switch (dataRow.GetCell(j).CellType)
                    {
                        case CellType.Formula:
                            value = dataRow.GetCell(j).StringCellValue.ToString();
                            break;
                        default:
                            value = dataRow.GetCell(j).ToString();
                            break;
                    }*/
                    if (dataRow.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                    {
                        ICell cell = dataRow.GetCell(j);
                        value = GetCellValue(cell).ToString();
                    }

                    // 记录可能出错数据
                    rowDatas.Add(value);

                    // 检查空值
                    if (!this.CheckNull(value, ref nullcount))
                    {
                        // 检查类型
                        if (!this.CheckDataType(header.DataType, value))
                        {
                            isrowfalse = true;
                            result.Success = false;
                            // 记录该行错误信息
                            rowErrorCell.Add(j + 1);
                            rowErrorMessages.Add("读取EXCEL数据时发生数据格式错误，请检查该行该列数据格式！");
                        }
                        else
                        {
                            if (header.DataType == "System.string" || header.DataType == "System.String")
                            {
                                this.ReplaceSpace(ref value);
                            }
                        }
                    }
                }
                // 报错处理(空行不报错)
                if (isrowfalse && nullcount < cellCount)
                {
                    sheetErrors.Add(new ExcelFileErrorPosition
                    {
                        RowContent = rowDatas,
                        RowIndex = i + 1,
                        CellIndex = rowErrorCell,
                        ErrorMessage = rowErrorMessages
                    });
                }
            }
            result.ExcelFileErrorPositions = sheetErrors;
            return result;
        }
    }
}
