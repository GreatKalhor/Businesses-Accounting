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

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute]
    public class BusinessProductsController : Controller
    {
        private readonly BA_dbContext _context;

        public BusinessProductsController(BA_dbContext context)
        {
            _context = context;
        }

        // GET: BusinessProducts
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.BusinessProducts.Include(b => b.Business).Include(b => b.Category);
            return View(await bA_dbContext.ToListAsync());
        }

        // GET: BusinessProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessProducts == null)
            {
                return NotFound();
            }

            var businessProduct = await _context.BusinessProducts
                .Include(b => b.Business)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessProduct == null)
            {
                return NotFound();
            }

            return View(businessProduct);
        }

        // GET: BusinessProducts/Create
        public IActionResult Create()
        {
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName");
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title");
            return View();
        }

        // POST: BusinessProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BusinessId,Name,IsActive,ProductCode,Barcode,CategoryId,SalesPrice,SalesInformation,PurchaseCost,PurchaseInformation,MainUnit,Note,SubUnit,UnitConversionFactor,TrackQuantity,ReorderPoint,MinimumOrder,LeadTimeDays,SalesTaxable,SalesTax,PurchaseTaxable,PurchaseTax,TaxId,TaxUnitId,IranianTaxTypeId,ImageUrl")] BusinessProduct businessProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessProduct.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessProduct.CategoryId);
            return View(businessProduct);
        }

        // GET: BusinessProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessProducts == null)
            {
                return NotFound();
            }

            var businessProduct = await _context.BusinessProducts.FindAsync(id);
            if (businessProduct == null)
            {
                return NotFound();
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessProduct.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessProduct.CategoryId);
            return View(businessProduct);
        }

        // POST: BusinessProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessId,Name,IsActive,ProductCode,Barcode,CategoryId,SalesPrice,SalesInformation,PurchaseCost,PurchaseInformation,MainUnit,Note,SubUnit,UnitConversionFactor,TrackQuantity,ReorderPoint,MinimumOrder,LeadTimeDays,SalesTaxable,SalesTax,PurchaseTaxable,PurchaseTax,TaxId,TaxUnitId,IranianTaxTypeId,ImageUrl")] BusinessProduct businessProduct)
        {
            if (id != businessProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessProductExists(businessProduct.Id))
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
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessProduct.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", businessProduct.CategoryId);
            return View(businessProduct);
        }

        // GET: BusinessProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessProducts == null)
            {
                return NotFound();
            }

            var businessProduct = await _context.BusinessProducts
                .Include(b => b.Business)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessProduct == null)
            {
                return NotFound();
            }

            return View(businessProduct);
        }

        // POST: BusinessProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessProducts == null)
            {
                return Problem("Entity set 'BA_dbContext.BusinessProducts'  is null.");
            }
            var businessProduct = await _context.BusinessProducts.FindAsync(id);
            if (businessProduct != null)
            {
                _context.BusinessProducts.Remove(businessProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessProductExists(int id)
        {
          return (_context.BusinessProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
