using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace FATC.Common.Extensions
{
    public static  class ExpressionsExtensions
    {
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
