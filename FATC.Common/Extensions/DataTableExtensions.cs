using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FATC.Common.Extensions
{
    public static class DataTableExtensions
    {
        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.Rows.OfType<DataRow>().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }

        public static List<T> ConvertToListUpperFields<T>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.Rows.OfType<DataRow>().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToUpper()))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        if (row[pro.Name.ToUpper()] == DBNull.Value)
                            pro.SetValue(objT, null);
                        else
                        {
                            //var propertyType = pro.PropertyType;
                            //if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            //    pro.SetValue(objT,  row[pro.Name.ToUpper()]);
                            //else
                            pro.SetValue(objT, ((row[pro.Name.ToUpper()]).ChangeType(pI.PropertyType)));
                        }
                        //pro.SetValue(objT, row[pro.Name.ToUpper()] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name.ToUpper()], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
