using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Businesses_Accounting.Data;
using Businesses_Accounting.Models;

namespace Businesses_Accounting.Controllers
{
    public class AccountingJournalsController : Controller
    {
        private readonly BA_dbContext _context;

        public AccountingJournalsController(BA_dbContext context)
        {
            _context = context;
        }

        // GET: AccountingJournals
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.AccountingJournals.Include(a => a.Account).Include(a => a.Currency).Include(a => a.Document).Include(a => a.SubAccountNavigation);
            return View(await bA_dbContext.ToListAsync());
        }

        // GET: AccountingJournals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountingJournals == null)
            {
                return NotFound();
            }

            var accountingJournal = await _context.AccountingJournals
                .Include(a => a.Account)
                .Include(a => a.Currency)
                .Include(a => a.Document)
                .Include(a => a.SubAccountNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountingJournal == null)
            {
                return NotFound();
            }

            return View(accountingJournal);
        }

        // GET: AccountingJournals/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Name");
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName");
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id");
            ViewData["SubAccountId"] = new SelectList(_context.SubAccounts, "Id", "Name");
            return View();
        }

        // POST: AccountingJournals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocumentId,AccountId,SubAccountId,SubAccount,Description,Debit,Credit,CurrencyId,Amount")] AccountingJournal accountingJournal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountingJournal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Name", accountingJournal.AccountId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", accountingJournal.CurrencyId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", accountingJournal.DocumentId);
            ViewData["SubAccountId"] = new SelectList(_context.SubAccounts, "Id", "Name", accountingJournal.SubAccountId);
            return View(accountingJournal);
        }

        // GET: AccountingJournals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountingJournals == null)
            {
                return NotFound();
            }

            var accountingJournal = await _context.AccountingJournals.FindAsync(id);
            if (accountingJournal == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Name", accountingJournal.AccountId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", accountingJournal.CurrencyId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", accountingJournal.DocumentId);
            ViewData["SubAccountId"] = new SelectList(_context.SubAccounts, "Id", "Name", accountingJournal.SubAccountId);
            return View(accountingJournal);
        }

        // POST: AccountingJournals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentId,AccountId,SubAccountId,SubAccount,Description,Debit,Credit,CurrencyId,Amount")] AccountingJournal accountingJournal)
        {
            if (id != accountingJournal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingJournal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingJournalExists(accountingJournal.Id))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Name", accountingJournal.AccountId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "DisplayName", accountingJournal.CurrencyId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", accountingJournal.DocumentId);
            ViewData["SubAccountId"] = new SelectList(_context.SubAccounts, "Id", "Name", accountingJournal.SubAccountId);
            return View(accountingJournal);
        }

        // GET: AccountingJournals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountingJournals == null)
            {
                return NotFound();
            }

            var accountingJournal = await _context.AccountingJournals
                .Include(a => a.Account)
                .Include(a => a.Currency)
                .Include(a => a.Document)
                .Include(a => a.SubAccountNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountingJournal == null)
            {
                return NotFound();
            }

            return View(accountingJournal);
        }

        // POST: AccountingJournals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountingJournals == null)
            {
                return Problem("Entity set 'BA_dbContext.AccountingJournals'  is null.");
            }
            var accountingJournal = await _context.AccountingJournals.FindAsync(id);
            if (accountingJournal != null)
            {
                _context.AccountingJournals.Remove(accountingJournal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountingJournalExists(int id)
        {
          return (_context.AccountingJournals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
