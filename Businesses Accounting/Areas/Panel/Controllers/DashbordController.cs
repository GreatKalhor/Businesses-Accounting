using Microsoft.AspNetCore.Mvc;

namespace Businesses_Accounting.Areas.Panel.Controllers
{

    [Area("Panel")]
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
    }
}
