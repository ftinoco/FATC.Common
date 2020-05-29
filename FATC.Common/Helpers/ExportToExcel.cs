using FATC.Common.Extensions;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FATC.Common.Helpers
{
    public class ExportToExcel<TEntity>
    {
        public static byte[] GenerateExcel(ReportEntity entity)
        {
            string tmpFile = $"{Path.GetDirectoryName(entity.TemplatePath)}\\{Guid.NewGuid()}_report.xlsx";
            try
            {
                File.Copy(entity.TemplatePath, tmpFile, true);
                var destFileInfo = new FileInfo(tmpFile);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream fs = File.OpenRead(tmpFile))
                    {
                        using (ExcelPackage excelPackage = new ExcelPackage(fs))
                        {
                            ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                            ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets.FirstOrDefault(x => x.Name.Equals(entity.SheetName));
                            var tuple = CreateHeaderRow(excelWorksheet, entity.ExcelEntities);
                            excelPackage.SaveAs(ms); // This is the important part.
                        }

                        ms.Position = 0;
                        var result = ms.ToArray();
                        ms.Flush();

                        if (File.Exists(tmpFile))
                            File.Delete(tmpFile);

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);
                throw ex;
            }
        }

        private static (uint index, List<TEntity> entities) CreateHeaderRow(ExcelWorksheet excelWorksheet, List<ExcelEntity> entities)
        {
            int columnIndex = 0;
            uint indexHeader = 0;
            List<TEntity> lst = new List<TEntity>();

            foreach (var entity in entities)
            {
                if (entity.Value == null) continue;

                if (entity.Value.IsList())
                {
                    lst = (List<TEntity>)entity.Value;

                    //Row header = new Row();
                    //header.RowIndex = entity.RowIndex;
                    //indexHeader = entity.RowIndex;

                    //var properties = typeof(TEntity).GetProperties();
                    //foreach (var pro in properties)
                    //{
                    //    var displayAttribute = pro.GetCustomAttribute<DisplayAttribute>();
                    //    if (displayAttribute != null)
                    //    {
                    //        Cell headerCell = CreateCell(displayAttribute.Name, true);
                    //        headerCell.CellReference = entity.ColumnName;
                    //        header.Append(headerCell);
                    //        columnIndex++;
                    //    }
                    //}
                    //sheetData.AppendChild(header);
                }
                else
                {
                    excelWorksheet.Cells[entity.RowIndex, entity.ColumnName].Value = entity.Value.ToString();
                    //Cell cell = GetCell(worksheetPart.Worksheet, entity.ColumnName, entity.RowIndex);
                    //cell.CellValue = new CellValue(entity.Value.ToString());
                    //cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }
                // Save the worksheet.
                //worksheetPart.Worksheet.Save();
            }
            return (indexHeader, lst);
        } 
    }
}
