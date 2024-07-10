using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace NPCIL.Controllers
{
    public class CheckSession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        
        {
            try
            {
                var ctx = filterContext.HttpContext;
                string vvvv = ctx.Request.Cookies["NPCIL_username"];
                if (ctx.Request.Cookies["NPCIL_username"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Logout", controller = "Login" }));
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Logout", controller = "Login" }));
            }
        }





    }
}
