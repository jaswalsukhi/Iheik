using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace Iheik.Plumbing
{
    public class WindsorActionInvoker : ControllerActionInvoker
    {
        private readonly IKernel _kernel;

        public WindsorActionInvoker(IKernel kernel)
        {
            this._kernel = kernel;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            foreach (IActionFilter actionFilter in filters)
            {
                _kernel.InjectProperties(actionFilter);
            }

            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }

        protected override ExceptionContext InvokeExceptionFilters(ControllerContext controllerContext, IList<IExceptionFilter> filters, System.Exception exception)
        {
            foreach (IExceptionFilter actionFilter in filters)
            {
                _kernel.InjectProperties(actionFilter);
            }
            return base.InvokeExceptionFilters(controllerContext, filters, exception);
        }

    }
}