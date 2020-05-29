using System.Collections;
using System.Collections.Generic;

namespace FATC.Common.Extensions
{
    public static class ObjectExtensions
    { 
        public static bool IsList(this object value)
        {
            if (value == null) return false;
            return value is IList &&
                   value.GetType().IsGenericType &&
                   value.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
    }
}
