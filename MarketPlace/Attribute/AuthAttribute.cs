using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Attribute
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool auth = filterContext.HttpContext.User.IsInRole("Admin");
            if (!auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                { "controller", "Home" }, { "action", "Index" }
                });
            }
        }
    }
}