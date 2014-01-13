using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Portfolio.Lib
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Casts a collection to a <see cref="SelectList"/>.
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="valueExpression">Value</param>
        /// <param name="textExpression">Display text</param>
        public static SelectList ToSelectList<T>(
            this IEnumerable<T> collection,
            Expression<Func<T, object>> valueExpression,
            Expression<Func<T, object>> textExpression)
        {
            string value = GetMemberNameFromExpression(valueExpression);
            string text = GetMemberNameFromExpression(textExpression);
            return new SelectList(collection, value, text);
        }

        /// <summary>
        /// Casts a collection to a <see cref="SelectList"/>.
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="valueExpression">Value</param>
        /// <param name="textExpression">Display text</param>
        /// <param name="selectedValue">Selected value in the collection</param>        
        public static SelectList ToSelectList<T>(
            this IEnumerable<T> collection,
            Expression<Func<T, object>> valueExpression,
            Expression<Func<T, object>> textExpression,
            object selectedValue)
        {
            string value = GetMemberNameFromExpression(valueExpression);
            string text = GetMemberNameFromExpression(textExpression);
            return new SelectList(collection, value, text, selectedValue);
        }

        private static string GetMemberNameFromExpression<T>(Expression<Func<T, object>> valueExpression)
        {
            MemberExpression memberExpression = valueExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                UnaryExpression body = valueExpression.Body as UnaryExpression;
                Contract.Assert(body != null);
                memberExpression = body.Operand as MemberExpression;
                Contract.Assert(memberExpression != null);
            }

            return memberExpression.Member.Name;            
        }
    }
}