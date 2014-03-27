using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iheik.Attributes
{
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// can be used like in enums like         
        /// [StringValue("SystemAdmin")]
        /// SystemAdmin = 2
        /// can be helpful when you need string value of enum Check Enum Extensions 
        /// </summary>
        public string StringValue { get; protected set; }

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

    }
}