using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Businesses_Accounting.Areas.Panel.Controllers
{

    [Area("Panel")]
    [Authorize]
    public class DashbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SideBar()
        {
            return PartialView();
        }

        public IActionResult UserInfo()
        {
            var model= CurrentUser.GetUser(User);
            return PartialView(model);
        }
    }
}
