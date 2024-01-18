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

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class BusinessBankingsController : Controller
    {
        private readonly BA_dbContext _context;

        public BusinessBankingsController(BA_dbContext context)
        {
            _context = context;
        }
        // GET: BusinessBankings
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.BusinessBankings.Include(b => b.Banking).Include(b => b.Business).Include(b => b.Currency);
            return View(await bA_dbContext.ToListAsync());
        }
        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            var userpanel = HttpContext.ToPanelViewModel();
            var result = _context.Contacts.Where(x => x.BusinessId == userpanel.BusinessId);
            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

        // GET: BusinessBankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessBankings == null)
            {
                return NotFound();
            }

            var businessBanking = await _context.BusinessBankings
                .Include(b => b.Banking)
                .Include(b => b.Business)
                .Include(b => b.Currency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessBanking == null)
            {
                return NotFound();
            }

            return View(businessBanking);
        }

        // GET: BusinessBankings/Create
        public IActionResult Create()
        {
            var userpanel = HttpContext.ToPanelViewModel();
            return View(new BusinessBanking() { BusinessId = userpanel.BusinessId });
        }

        // POST: BusinessBankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessBanking businessBanking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessBanking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankingId"] = new SelectList(_context.BankingTypes, "Id", "Name", businessBanking.BankingId);
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessBanking.BusinessId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", businessBanking.CurrencyId);
            return View(businessBanking);
        }

        // GET: BusinessBankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessBankings == null)
            {
                return NotFound();
            }

            var businessBanking = await _context.BusinessBankings.FindAsync(id);
            if (businessBanking == null)
            {
                return NotFound();
            }
            ViewData["BankingId"] = new SelectList(_context.BankingTypes, "Id", "Name", businessBanking.BankingId);
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessBanking.BusinessId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", businessBanking.CurrencyId);
            return View(businessBanking);
        }

        // POST: BusinessBankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessId,BankingId,IsActive,Name,CurrencyId,IsDefault,Note")] BusinessBanking businessBanking)
        {
            if (id != businessBanking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessBanking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessBankingExists(businessBanking.Id))
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
            ViewData["BankingId"] = new SelectList(_context.BankingTypes, "Id", "Name", businessBanking.BankingId);
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", businessBanking.BusinessId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", businessBanking.CurrencyId);
            return View(businessBanking);
        }

        // GET: BusinessBankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessBankings == null)
            {
                return NotFound();
            }

            var businessBanking = await _context.BusinessBankings
                .Include(b => b.Banking)
                .Include(b => b.Business)
                .Include(b => b.Currency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessBanking == null)
            {
                return NotFound();
            }

            return View(businessBanking);
        }

        // POST: BusinessBankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessBankings == null)
            {
                return Problem("Entity set 'BA_dbContext.BusinessBankings'  is null.");
            }
            var businessBanking = await _context.BusinessBankings.FindAsync(id);
            if (businessBanking != null)
            {
                _context.BusinessBankings.Remove(businessBanking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessBankingExists(int id)
        {
            return (_context.BusinessBankings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
