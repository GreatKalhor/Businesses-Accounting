using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Mvc;

namespace Businesses_Accounting.Controllers
{
    public class GreatController : Controller
    {
        public UIBIBFYISviewModel PanelUser { get { return HttpContext.ToPanelViewModel(); } }
        public Guid? CurrentUserId { get { return CurrentUser.GetUserId(User); } }
    }
}
