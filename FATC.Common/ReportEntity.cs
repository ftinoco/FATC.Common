using System.Collections.Generic;

namespace FATC.Common
{
    public class ReportEntity
    {
        public string TemplatePath { get; set; }

        public string SheetName { get; set; }

        public List<ExcelEntity> ExcelEntities { get; set; }

    }

    public class ExcelEntity
    {
        public int RowIndex { get; set; }

        public int ColumnName { get; set; }

        public object Value { get; set; }
    }
}
