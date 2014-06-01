using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.Utilities.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether a string exists in a specified source string.
        /// </summary>
        /// <param name="source">String The source.</param>
        /// <param name="toCheck">String to check.</param>
        /// <param name="comparer">StringComparison to use.</param>
        /// <returns>Boolean - True for the existence of the text in the string.</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comparer)
        {
            return source.IndexOf(toCheck, comparer) >= 0;
        }

        /// <summary>
        /// Determines whether [contains] [the specified source].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="toCheck">To check.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="temp">The temp.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(this string source, string toCheck, StringComparison comparer, string temp)
        {
            bool stringIsPresent = false;
            int len = toCheck.Length;

            try
            {
                for (int i = 0; i < source.Length - len; i++)
                {
                    if (string.Equals(source.Substring(i, len), toCheck, comparer))
                    {
                        stringIsPresent = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                stringIsPresent = false;
            }

            return stringIsPresent;
        }



        /// <summary>
        /// Enforces the length of a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns>String - truncated as required.</returns>
        public static string EnforceLength(this string sourceString, int maximumLength)
        {
            return EnforceLength(sourceString, 0, maximumLength);
        }

        /// <summary>
        /// Enforces the length of a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns>String - truncated or padded as required.</returns>
        public static string EnforceLength(this string sourceString, int minimumLength, int maximumLength)
        {
            string result = sourceString;

            if (sourceString.Length < minimumLength)
            {
                result = result.PadRight(minimumLength, '*');
            }
            else if (sourceString.Length > maximumLength)
            {
                result = result.Remove(maximumLength);
            }

            return result;
        }

        /// <summary>
        /// Truncates the length.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns>String - truncated as required.</returns>
        public static string TruncateLength(this string sourceString, int maximumLength)
        {
            string result = sourceString;

            if (sourceString.Length > maximumLength)
            {
                result = result.Remove(maximumLength);
            }

            return result;
        }







    }
}
