using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;

namespace Iheik.Filters
{
    public class LogExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        // Dependencies
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };

            Logger.Error("Logging Filter", filterContext.Exception);
            filterContext.ExceptionHandled = true;

        }
    }
}