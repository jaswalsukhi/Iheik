using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Iheik.Attributes;

namespace Iheik.Extensions
{
    public static class EnumExtensions
    {

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            string stringValue = string.Empty;

            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            stringValue = attribs.Length > 0 ? attribs[0].StringValue : string.Empty;

            return stringValue;
        }
    }
}