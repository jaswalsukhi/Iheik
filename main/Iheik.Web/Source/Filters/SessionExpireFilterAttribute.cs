using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace Iheik.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var skipSessionExpirationCheck = filterContext.ActionDescriptor.IsDefined(typeof(IgnoreSessionExpireAttribute), true)
                                        || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(IgnoreSessionExpireAttribute), true);

            if (!skipSessionExpirationCheck)
            {
                HttpContext currentContext = HttpContext.Current;

                // check if session is supported
                if (currentContext.Session != null)
                {
                    // check if a new session id was generated
                    if (currentContext.Session.IsNewSession)
                    {
                        // If it says it is a new session, but an existing cookie exists, then it must have timed out
                        string sessionCookie = currentContext.Request.Headers["Cookie"];

                        if (sessionCookie != null && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            var req = new HttpRequestWrapper(System.Web.HttpContext.Current.Request);
                            if (req.IsAjaxRequest())
                            {
                                //do nothing as it is being handled in relevant ajax calls
                            }
                            else
                            {
                                //we can specify which action to be called in case session has expired
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "ControllerName" }, { "Action", "ActionName" } });
                            }

                        }
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}