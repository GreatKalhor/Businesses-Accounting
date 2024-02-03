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
using NuGet.Packaging.Signing;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class DocumentsController : GreatController
    {
        private readonly BA_dbContext _context;

        public DocumentsController(BA_dbContext context)
        {
            _context = context;
        }
        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.Documents.Include(d => d.BusinessFiscalYear).Include(d => d.Project);
            return View(await bA_dbContext.ToListAsync());

        }
        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            var userpanel = PanelUser;
            var result = _context.Documents.Where(x => x.BusinessFiscalYearId == userpanel.BusinessFiscalYearId);
            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
        [AcceptVerbs("Get", "Post")]
        public ActionResult Editing_Create([DataSourceRequest] DataSourceRequest request, IEnumerable<CreateAccountingJournalViewModel> models)
        {
            var ssss = Request;
            var _results = new List<CreateAccountingJournalViewModel>(models);
            var results = new List<CreateAccountingJournalViewModel>();
            for (int i = 0; i < _results.Count; i++)
            {
                var model = _results[i];
                if (model.AccountId.HasValue)
                {
                    using (AccountServices _as = new AccountServices(_context))
                    {
                        model.Accounttxt = _as.GetAccountsTextFromParents(model.AccountId.Value);
                    }
                }
                model.Id = i;
                model.DocumentId = i;
                model.CurrencyId = i;
                model.SubAccountId = i;
                results.Add(model);
            }
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Get", "Post")]
        public ActionResult Editing_Seva([FromBody] IEnumerable<CreateAccountingJournalViewModel> models)
        {
            var results = new List<CreateAccountingJournalViewModel>(models);
            var rrr = Request;
            // var results = new List<CreateAccountingJournalViewModel>();
            // results.Add(accountingJournal); 
            return Json("ok");
        }
        [AcceptVerbs("Get", "Post")]
        public ActionResult Editing_Read([DataSourceRequest] DataSourceRequest request, IEnumerable<CreateAccountingJournalViewModel> accountingJournal)
        {
            var results = new List<CreateAccountingJournalViewModel>(accountingJournal);
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Get", "Post")]
        public ActionResult Editing_Update([DataSourceRequest] DataSourceRequest request, IEnumerable<CreateAccountingJournalViewModel> models)
        {
            var _results = new List<CreateAccountingJournalViewModel>(models);
            var results = new List<CreateAccountingJournalViewModel>();
            for (int i = 0; i < _results.Count; i++)
            {
                var model = _results[i];
                if (model.AccountId.HasValue)
                {
                    using (AccountServices _as = new AccountServices(_context))
                    {
                        model.Accounttxt = _as.GetAccountsTextFromParents(model.AccountId.Value);
                    }
                }
                model.Id = i;
                model.DocumentId = i;
                model.CurrencyId = i;
                model.SubAccountId = i;
                results.Add(model);
            }
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Get", "Post")]
        public ActionResult Editing_Destroy([DataSourceRequest] DataSourceRequest request, CreateAccountingJournalViewModel accountingJournal)
        {
            var results = new List<CreateAccountingJournalViewModel>();
            results.Add(accountingJournal);
            return Json(results.ToDataSourceResult(request, ModelState));
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.BusinessFiscalYear)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            var userpanel = PanelUser;

            return View(new Document() { BusinessFiscalYearId = userpanel.BusinessFiscalYearId, DocumentDate = DateTime.Now, InsertDate = DateTime.Now });
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Document document)
        {
            if (ModelState.IsValid)
            {
                var d = new Document()
                {
                    BusinessFiscalYearId = document.BusinessFiscalYearId,
                    DocumentDate = document.DocumentDate,
                    InsertDate = DateTime.Now,
                    Amount = document.AccountingJournals.Sum(s => s.Credit),
                    Description = document.Description,
                    Number = document.Number,
                    Reference = document.Reference,
                    ContactId = document.ContactId
                };
                _context.Add(d);
                await _context.SaveChangesAsync();
                using (CurrencyServices cs = new CurrencyServices(_context))
                {
                    int minacurrencyId = cs.GetMainCurrencyId(PanelUser.BusinessId);
                    foreach (var item in document.AccountingJournals)
                    {
                        if (item.Amount < 0)
                        {
                            item.Debit = -item.Amount;
                        }
                        else
                        {
                            item.Credit = item.Amount;
                        }
                        if (item.AccountId > 0 && (item.Debit > 0 || item.Credit > 0))
                        {
                            item.DocumentId = d.Id;
                            item.CurrencyId = minacurrencyId;
                            if (item.SubAccountId == 0)
                            {
                                item.SubAccountId = null;
                            }
                            _context.Add(item);
                        }
                    }
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Documents");
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.Where(c => c.Id == id.Value).Include(x => x.AccountingJournals).FirstOrDefaultAsync();
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var accountingJournals = _context.AccountingJournals.Where(x => x.DocumentId == document.Id);
                    List<AccountingJournal> fordel = new List<AccountingJournal>();
                    List<AccountingJournal> forup = new List<AccountingJournal>();
                    List<AccountingJournal> foradd = new List<AccountingJournal>();

                    if (document.AccountingJournals.Any())
                    {
                        var jids = document.AccountingJournals.Select(x => x.Id);
                        fordel.AddRange(accountingJournals.Where(x => !jids.Contains(x.Id)));
                        foradd.AddRange(document.AccountingJournals.Where(x => x.Id == 0));
                        using (CurrencyServices cs = new CurrencyServices(_context))
                        {
                            int minacurrencyId = cs.GetMainCurrencyId(PanelUser.BusinessId);
                            var collection = document.AccountingJournals.Where(x => x.Id != 0);
                            foreach (var item in collection)
                            {
                                if (item.CurrencyId == 0)
                                {
                                    item.CurrencyId = minacurrencyId;
                                }
                                if (item.SubAccountId == 0)
                                {
                                    item.SubAccountId = null;
                                }
                                if (item.Amount < 0)
                                {
                                    item.Debit = -item.Amount;
                                }
                                else
                                {
                                    item.Credit = item.Amount;
                                }


                                if (item.Debit == 0 && item.Credit == 0)
                                {
                                    fordel.Add(item);
                                }
                                else
                                {

                                    forup.Add(item);
                                }
                            }
                            if (fordel.Count > 0)
                            {
                                _context.RemoveRange(fordel);
                            }
                            if (forup.Count > 0)
                            {
                                _context.UpdateRange(forup);
                            }
                            foreach (var item in foradd)
                            {
                                if (item.Amount < 0)
                                {
                                    item.Debit = -item.Amount;
                                }
                                else
                                {
                                    item.Credit = item.Amount;
                                }

                                if (item.AccountId > 0 && (item.Debit > 0 || item.Credit > 0))
                                {
                                    item.DocumentId = document.Id;
                                    item.CurrencyId = minacurrencyId;
                                    if (item.SubAccountId == 0)
                                    {
                                        item.SubAccountId = null;
                                    }
                                    _context.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (accountingJournals.Any())
                        {
                            _context.RemoveRange(accountingJournals);
                        }
                    }

                    _context.Documents.Update(document);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index", "Documents");
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.BusinessFiscalYear)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var document = await _context.Documents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (document != null)
            {
                var ajs = _context.AccountingJournals.Where(a => a.DocumentId == document.Id).ToList();
                foreach (var item in ajs)
                {
                    _context.AccountingJournals.Remove(item);
                }
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
            }
            return Json("<p><span>عملیات با موفقیت انجام شد</span></p><p><span> در حال لود مجدد...</span>");
        }

        private bool DocumentExists(int id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
