using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FATC.Common.Helpers
{
    public class ObjectHelper
    {
        public static KeyValuePair<string, string> GetPropertyByName(object model, string property)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();
            if (model != null)
            {
                Type modelType = model.GetType();
                //object container = Activator.CreateInstance(modelType);
                PropertyInfo propertyInfo = modelType.GetProperties().Where(w => w.Name.Equals(property)).FirstOrDefault();
                if (propertyInfo != null)
                    kvp = new KeyValuePair<string, string>(propertyInfo.Name, propertyInfo.GetValue(model).ToString());
            }
            return kvp;
        }

        public static Dictionary<string, object> GetAllPropertiesModelUpperCase(object model, List<string> excludedColumns)
        {
            Dictionary<string, object> procedures = new Dictionary<string, object>();
            if (model != null)
            {
                Type modelType = model.GetType();
                //object container = Activator.CreateInstance(ModelType);
                foreach (PropertyInfo property in modelType.GetProperties().Where(w => !excludedColumns.Select(s => s).Contains(w.Name)))
                {
                    procedures.Add(property.Name.ToUpper(), property.GetValue(model).ToString());
                }
            }
            return procedures;
        }

        public static Dictionary<string, object> GetAllPropertiesModel(object model, List<string> excludedColumns)
        {
            Dictionary<string, object> procedures = new Dictionary<string, object>();
            if (model != null)
            {
                Type modelType = model.GetType();
                //object container = Activator.CreateInstance(ModelType);
                foreach (PropertyInfo property in modelType.GetProperties().Where(w => !excludedColumns.Select(s => s).Contains(w.Name)))
                {
                    procedures.Add(property.Name, property.GetValue(model).ToString());
                }
            }
            return procedures;
        }

        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}
