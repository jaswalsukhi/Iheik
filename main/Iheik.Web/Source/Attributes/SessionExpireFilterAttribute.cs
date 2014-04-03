using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace Iheik.Attributes
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

                        if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            currentContext.Response.RedirectToRoute(new RouteValueDictionary { { "Controller", "Home" }, { "Action", "TimeoutRedirect" } });
                        }
                    }
                }

                // If the browser session or authentication session has expired...
                if (currentContext.User.Identity.Name == null || !filterContext.HttpContext.Request.IsAuthenticated)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        // For AJAX requests, we're overriding the returned JSON result with a simple string,
                        // indicating to the calling JavaScript code that a redirect should be performed.
                        filterContext.Result = new JsonResult { Data = "_Logon_" };
                    }
                    else
                    {
                        // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                        // simply displays a temporary 5 second notification that they have timed out, and
                        // will, in turn, redirect to the logon page.
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Home" }, { "Action", "TimeoutRedirect" } });
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}