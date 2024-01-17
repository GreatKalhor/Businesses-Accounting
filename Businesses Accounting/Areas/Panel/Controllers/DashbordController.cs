using Businesses_Accounting.Data;
using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Businesses_Accounting.Areas.Panel.Controllers
{

    [Area("Panel")]
    [Authorize]
    public class DashbordController : Controller
    {
        private readonly BA_dbContext _context;

        public DashbordController(BA_dbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Check(int businessId)
        {
            if (businessId > 0)
            {
                var _userId = CurrentUser.GetUserId(User);
                using (BusinessServices bs = new BusinessServices(_context))
                {
                    var bss = await bs.GetBusinessWithUser(_userId);
                    if (bss != null && bss.Any(x => x.Id == businessId))
                    {
                        using (BusinessFiscalYearServices bfys = new BusinessFiscalYearServices(_context))
                        {
                            var bfyss = await bfys.GetWithBusinessId(businessId);
                            if (bfyss != null)
                            {
                                return RedirectToAction("Index", "App", new { area = "", ubis = PanelServices.GenerateUBselected(_userId.Value, businessId, bfyss.Id) });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Businesses", new { area = "", ubis = "" });
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Businesses", new { area = "", ubis = "" });
                    }
                }


            }
            else
            {

                return RedirectToAction("Index", "Businesses", new { area = "", ubis = "" });

            }
        }
        public async Task<IActionResult> Index(int businessId)
        {
            if (businessId == 0)
            {
                return RedirectToAction("Index", "Businesses", new { area = "", ubis = "" });
            }
            return View();
        }
        public IActionResult SideBar()
        {
            return PartialView();
        }

        public IActionResult UserInfo()
        {
            var model = CurrentUser.GetUser(User);
            return PartialView(model);
        }
    }
}
