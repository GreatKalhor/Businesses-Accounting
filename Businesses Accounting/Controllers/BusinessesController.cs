using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Businesses_Accounting.Services;
using Businesses_Accounting.Models.ViewModels;
using Businesses_Accounting.Resources;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    public class BusinessesController : GreatController
    {
        private readonly BA_dbContext _context;

        public BusinessesController(BA_dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                return View(await bs.GetBusinessWithUser(CurrentUserId));
            }
        }


        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                var result = bs.GetBusinessWithUser(CurrentUserId).Result;
                var dsResult = result.ToDataSourceResult(request);
                return Json(dsResult);
            }
        }

        public IActionResult Create()
        {
            return View(new CreateBusinessViewModel() { LanguageId = (DefaultValues.LanguageId != 0 ? DefaultValues.LanguageId : 1), MainCurrencyId = (DefaultValues.CurrencyId != 0 ? DefaultValues.CurrencyId : 1) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBusinessViewModel business)
        {
            var ss=Request;
            if (ModelState.IsValid)
            {
                using (BusinessServices bs = new BusinessServices(_context))
                {
                    int id = await bs.InsertBusiness(business, CurrentUserId);
                    return RedirectToAction("Check", "Dashbord", new { area = "Panel", businessId = id });
                }
            }
            return View(business);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            Business? business;
            using (BusinessServices bs = new BusinessServices(_context))
            {
                business = await bs.FindAsync(id.Value);
            }
            if (business == null)
            {
                return NotFound();
            }

            return View(new CreateBusinessViewModel(business));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateBusinessViewModel business)
        {
            if (ModelState.IsValid)
            {
                using (BusinessServices bs = new BusinessServices(_context))
                {
                    await bs.UpdateBusiness(business, CurrentUserId);
                }
                return RedirectToAction("Index", "Businesses");
            }
            return View(business);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (BusinessServices bs = new BusinessServices(_context))
            {
                var business = await bs.FindAsync(id.Value);
                if (business == null)
                {
                    return NotFound();
                }
                return View(business);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                await bs.DeleteBusiness(id, CurrentUserId);
            }
            return RedirectToAction("Index", "Businesses");
        }


    }
}
