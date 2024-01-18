using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Businesses_Accounting
{
    public class MyArgument
    {
        public bool CheckOnBatabase { get; set; }
    }
    public class GreatAttribute : TypeFilterAttribute
    {
        public GreatAttribute() : base(typeof(GreatActionFilter))
        {
        }
        public GreatAttribute(bool checkOndatabase) : base(typeof(GreatActionFilter))
        {
            Arguments = new object[] { new MyArgument() { CheckOnBatabase = checkOndatabase } };
        }

    }

    public class GreatActionFilter : IAuthorizationFilter
    {
        readonly bool checkOndatabase;
        public GreatActionFilter()
        {
            checkOndatabase = false;
        }
        public GreatActionFilter(MyArgument myArgument)
        {
            checkOndatabase = myArgument.CheckOnBatabase;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.ToPanelViewModel(checkOndatabase).IsValid)
            {
                context.Result = new RedirectToActionResult("Index", "Businesses", new { ubis = "" });
                //To do : before the action executes
            }
        }
    }

}
