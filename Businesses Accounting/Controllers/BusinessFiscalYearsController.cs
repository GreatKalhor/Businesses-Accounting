using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class BusinessFiscalYearsController : GreatController
    {
        private readonly BA_dbContext _context;

        public BusinessFiscalYearsController(BA_dbContext context)
        {
            _context = context;
        }
        // GET: BusinessFiscalYears
        public async Task<IActionResult> Index(int businessId, string ubis)
        {
            if (businessId > 0)
            {
                ViewData["businessId"] = businessId;
                var bA_dbContext = _context.BusinessFiscalYears.Where(x => x.BusinessId == businessId).Include(b => b.Business);
                return View(await bA_dbContext.ToListAsync());
            }
            else
            {
                return LocalRedirect(Url.Action("Index", "Dashbord", new { area = "Panel" }));
            }
        }
        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            var userpanel = PanelUser;
            var result = _context.Contacts.Where(x => x.BusinessId == userpanel.BusinessId);
            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

        // GET: BusinessFiscalYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessFiscalYears == null)
            {
                return NotFound();
            }

            var businessFiscalYear = await _context.BusinessFiscalYears
                .Include(b => b.Business)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessFiscalYear == null)
            {
                return NotFound();
            }

            return View(businessFiscalYear);
        }

        // GET: BusinessFiscalYears/Create
        public IActionResult Create()
        {
            var userpanel = HttpContext.ToPanelViewModel();
            int businessId = userpanel.BusinessId;
            if (businessId > 0)
            {
                return View(new BusinessFiscalYear() { BusinessId = businessId });
            }
            else
            {
                return LocalRedirect(Url.Action("Index", "Dashbord", new { area = "Panel" }));
            }
        }

        // POST: BusinessFiscalYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BusinessFiscalYear businessFiscalYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessFiscalYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(Url.Action("Index", new { businessId = businessFiscalYear.BusinessId }));
            }
            return View(businessFiscalYear);
        }

        // GET: BusinessFiscalYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessFiscalYears == null)
            {
                return NotFound();
            }

            var businessFiscalYear = await _context.BusinessFiscalYears.FindAsync(id);
            if (businessFiscalYear == null)
            {
                return NotFound();
            }
            return View(businessFiscalYear);
        }

        // POST: BusinessFiscalYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessId,StartDate,EndDate,Title,InventoryValuationMethod")] BusinessFiscalYear businessFiscalYear)
        {
            if (id != businessFiscalYear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessFiscalYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessFiscalYearExists(businessFiscalYear.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(Url.Action("Index", new { businessId = businessFiscalYear.BusinessId }));
            }
            return View(businessFiscalYear);
        }

        // GET: BusinessFiscalYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessFiscalYears == null)
            {
                return NotFound();
            }

            var businessFiscalYear = await _context.BusinessFiscalYears
                .Include(b => b.Business)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessFiscalYear == null)
            {
                return NotFound();
            }

            return View(businessFiscalYear);
        }

        // POST: BusinessFiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessFiscalYears == null)
            {
                return Problem("Entity set 'BA_dbContext.BusinessFiscalYears'  is null.");
            }
            var businessFiscalYear = await _context.BusinessFiscalYears.FindAsync(id);
            if (businessFiscalYear != null)
            {
                _context.BusinessFiscalYears.Remove(businessFiscalYear);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(Url.Action("Index", new { businessId = businessFiscalYear.BusinessId }));
        }

        private bool BusinessFiscalYearExists(int id)
        {
            return (_context.BusinessFiscalYears?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
