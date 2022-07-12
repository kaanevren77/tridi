using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tridi.Models;

namespace Tridi.Filters
{
    public class SessionCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            UserModel? user = Utilities.SessionExtensions.Get<UserModel>(filterContext.HttpContext.Session, "Login");
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }

            base.OnActionExecuting(filterContext);

        }
    }
}
