using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace FATC.Common.Extensions
{
    public static class ListExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, List<string> excludedColumns)
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(w => !excludedColumns.Select(s => s).Contains(w.Name)).ToList().ToArray();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
                dataTable.Columns.Add(new DataColumn(info.Name, info.PropertyType));

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length - 1 + 1];
                for (int i = 0; i <= properties.Length - 1; i++)
                    values[i] = properties[i].GetValue(entity);

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static DataTable ToDataTableUpperFields<T>(this IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties().ToList().ToArray();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
                dataTable.Columns.Add(new DataColumn(info.Name.ToUpper(), Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length - 1 + 1];
                for (int i = 0; i <= properties.Length - 1; i++)
                    values[i] = properties[i].GetValue(entity);

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
         
        public static DataTable ToDataTableUpperFields<T>(this IEnumerable<T> list, List<string> excludedColumns)
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(w => !excludedColumns.Select(s => s).Contains(w.Name)).ToList().ToArray();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
                dataTable.Columns.Add(new DataColumn(info.Name.ToUpper(), Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length - 1 + 1];
                for (int i = 0; i <= properties.Length - 1; i++)
                    values[i] = properties[i].GetValue(entity);

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
