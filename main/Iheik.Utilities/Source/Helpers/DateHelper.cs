using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.Utilities.Helpers
{
    public static class DateHelper
    {

        public static string FormatDateAndTime(DateTime date, TimeSpan time)
        {
            // format output - yyyy-MM-dd'T'HH:mm:ssZ (e.g. 2006-06-12T17:15:55+1000) 
            string formatedDateTime = string.Format("{0:yyyy-MM-ddT}{1}", date, time) + string.Format("{0:zzz}", date).Replace(":", string.Empty);

            return formatedDateTime;
        }

        public static string FormatDateAndTime(DateTime date)
        {
            // format output - yyyy-MM-dd'T'HH:mm:ssZ (e.g. 2006-06-12T17:15:55+1000) 
            var time = new TimeSpan(date.Hour, date.Minute, date.Second);

            string formatedDateTime = string.Format("{0:yyyy-MM-ddT}{1}", date, time) + string.Format("{0:zzz}", date).Replace(":", string.Empty);

            return formatedDateTime;
        }

        public static string FormatForSiebelDateAndTime(DateTime date)
        {
            // format output - YYYY/MM/DD HH:MM:SS 
            //string formatedDateTime = string.Format("{0:dd-MM-yyyy HH:mm:ss}", date);

            string formatedDateTime = string.Format("{0:dd-MM-yyyy}", date);

            return formatedDateTime;
        }

    }
}
