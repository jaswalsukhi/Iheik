using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iheik.ServiceInteractions.Enums;

namespace Iheik.ServiceInteractions.EnquiryFactory
{
    public class EnquiryResult
    {
        public string EnquiryNumber { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
