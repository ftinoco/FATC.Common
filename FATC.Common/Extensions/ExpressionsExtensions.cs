using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace FATC.Common.Extensions
{
    public static  class ExpressionsExtensions
    {
        public static string GetPropertyDisplayName<T>(this Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
                throw new ArgumentException($"No se encontró la propiedad en la expresión proporcionada");

            var attr = memberInfo.GetAttribute<DisplayAttribute>(false);
            if (attr == null)
                return memberInfo.Name;

            return attr.Name;
        }

        public static string GetPropertyRequiredMessage<T>(this Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
                throw new ArgumentException($"No se encontró la propiedad en la expresión proporcionada");

            var attr = memberInfo.GetAttribute<RequiredAttribute>(false);
            if (attr == null)
                return memberInfo.Name;

            return attr.ErrorMessage;
        }

        public static MemberInfo GetPropertyInformation(this Expression propertyExpression)
        {
            Debug.Assert(propertyExpression != null, "propertyExpression != null");
            MemberExpression memberExpression = propertyExpression as MemberExpression;
            if (memberExpression == null)
            {
                UnaryExpression unaryExpression = propertyExpression as UnaryExpression;
                if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)
                    memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression != null && memberExpression.Member.MemberType == MemberTypes.Property)
                return memberExpression.Member;

            return null;
        }
    }
}
