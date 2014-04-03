using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace Iheik.Attributes
{
    public class RequireAuthenticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                                   || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization)
            {
                base.HandleUnauthorizedRequest(filterContext);

                // send them to the login screen with a session expiration message
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Account" }, { "Action", "LogOn" }, { "id", "SessionExpired" } });
            }
        }
    }
}