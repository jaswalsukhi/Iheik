using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Iheik.Validation
{
    public class AlphaNumericAttribute : RegularExpressionAttribute
    {
        public AlphaNumericAttribute()
            : base(GetRegex())
        { }

        private static string GetRegex()
        {
            string alphaNumericFormat = @"^[A-Za-z0-9]+$";

            return alphaNumericFormat;
        }

    }
}
