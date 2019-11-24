using System;
using System.Linq;
using System.Reflection;

namespace FATC.Common.Extensions
{
    public static class MemberInfoExtensions
    {
        public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
                throw new ArgumentException($"El atributo {typeof(T).Name} debe estar definido en {member.Name}");

            return (T)attribute;
        }

    }
}
