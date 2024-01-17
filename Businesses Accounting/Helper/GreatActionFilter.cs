using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Businesses_Accounting
{
    public class GreatAttribute : TypeFilterAttribute
    {
        public GreatAttribute() : base(typeof(GreatActionFilter))
        {
        }
       

    }

    public class GreatActionFilter : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.ToPanelViewModel().IsValid)
            {
                context.Result =new RedirectToActionResult("Index", "Businesses", new {ubis="" });
                //To do : before the action executes
            }
        }
    }
    
}
