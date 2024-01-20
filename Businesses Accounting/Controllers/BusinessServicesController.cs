using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.AspNetCore.Authorization;
using Businesses_Accounting.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using static Businesses_Accounting.Resources.Variable;
using Businesses_Accounting.Models.ViewModels;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class BusinessServicesController : Controller
    {
        private readonly BA_dbContext _context;

        public BusinessServicesController(BA_dbContext context)
        {
            _context = context;
        }
        // GET: BusinessServices
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.BusinessServices.Include(b => b.Business).Include(b => b.Category);
            return View(await bA_dbContext.ToListAsync());
        }
        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            var userpanel = HttpContext.ToPanelViewModel();
            var result = _context.BusinessServices.Where(x => x.BusinessId == userpanel.BusinessId);
            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
        // GET: BusinessServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessServices == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessServices
                .Include(b => b.Business)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessService == null)
            {
                return NotFound();
            }

            return View(businessService);
        }

        // GET: BusinessServices/Create
        public IActionResult Create()
        {
            var userpanel = HttpContext.ToPanelViewModel();
            return View(new CreatBusinessServiceViewModel() { BusinessId = userpanel.BusinessId, CategoryId = _context.BusinessCategories.FirstOrDefault(c => c.BusinessId == userpanel.BusinessId && c.CategoryType == (int)CategoryType.Service).Id });
        }

        // POST: BusinessServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessService businessService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessService.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessService.CategoryId);
            return View(businessService);
        }

        // GET: BusinessServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessServices == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessServices.FindAsync(id);
            if (businessService == null)
            {
                return NotFound();
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessService.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessService.CategoryId);
            return View(businessService);
        }

        // POST: BusinessServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessId,Name,IsActive,ProductCode,Barcode,CategoryId,SalesPrice,SalesInformation,PurchaseCost,PurchaseInformation,MainUnit,Note,SubUnit,UnitConversionFactor,SalesTaxable,SalesTax,PurchaseTaxable,PurchaseTax,TaxId,TaxUnitId,IranianTaxTypeId,ImageUrl")] BusinessService businessService)
        {
            if (id != businessService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessServiceExists(businessService.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessService.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessService.CategoryId);
            return View(businessService);
        }

        // GET: BusinessServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessServices == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessServices
                .Include(b => b.Business)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessService == null)
            {
                return NotFound();
            }

            return View(businessService);
        }

        // POST: BusinessServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessServices == null)
            {
                return Problem("Entity set 'BA_dbContext.BusinessServices'  is null.");
            }
            var businessService = await _context.BusinessServices.FindAsync(id);
            if (businessService != null)
            {
                _context.BusinessServices.Remove(businessService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessServiceExists(int id)
        {
          return (_context.BusinessServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
