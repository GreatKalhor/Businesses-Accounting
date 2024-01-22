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
    public class DocumentsController : Controller
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
            var userpanel = HttpContext.ToPanelViewModel();
            var result = _context.Documents.Where(x => x.BusinessFiscalYearId == userpanel.BusinessFiscalYearId);
            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        } 
        [AcceptVerbs("Post")]
        public ActionResult Editing_Create([DataSourceRequest] DataSourceRequest request, IEnumerable<CreateAccountingJournalViewModel> models)
        {
            var _results = new List<CreateAccountingJournalViewModel>(models);
            var results = new List<CreateAccountingJournalViewModel>();
            for (int i = 0; i < _results.Count; i++)
            {
                var model = _results[i];
                model.Id = i;
                model.DocumentId = i;
                model.CurrencyId = i;
                model.SubAccountId = i;
                results.Add(model);
            }
            return Json(results.ToDataSourceResult(request, ModelState));
        }
    
        public ActionResult Editing_Seva([FromBody]  IEnumerable<CreateAccountingJournalViewModel> models)
        {
            var results = new List<CreateAccountingJournalViewModel>(models);
            var rrr = Request;
            // var results = new List<CreateAccountingJournalViewModel>();
            // results.Add(accountingJournal); 
            return Json("ok");
        }
        [AcceptVerbs("Post")]
        public ActionResult Editing_Read([DataSourceRequest] DataSourceRequest request,  IEnumerable<CreateAccountingJournalViewModel> accountingJournal)
        {
            var results = new List<CreateAccountingJournalViewModel>(accountingJournal);
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
        public ActionResult Editing_Update([DataSourceRequest] DataSourceRequest request,  IEnumerable<CreateAccountingJournalViewModel> accountingJournal)
        {
            var results = new List<CreateAccountingJournalViewModel>(accountingJournal);
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
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
            var userpanel = HttpContext.ToPanelViewModel();
       
            return View(new Document() { BusinessFiscalYearId = userpanel.BusinessFiscalYearId,DocumentDate=DateTime.Now,InsertDate=DateTime.Now });
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
                    Amount = document.AccountingJournals.Sum(s=>s.Credit),
                    Description = document.Description,
                    Number = document.Number,
                    Reference = document.Reference
                };
                _context.Add(d);
                await _context.SaveChangesAsync();
                    var c = _context.Currencies.Where(x => x.Name.Contains("IRR")).FirstOrDefault();
                foreach (var item in document.AccountingJournals)
                {
                    item.DocumentId = d.Id;
                    item.CurrencyId = c.Id;
                    _context.Add(item);
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

            var document = await _context.Documents.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessFiscalYearId,Number,Reference,InsertDate,ProjectId,Description,DocumentDate,Amount")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'BA_dbContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Documents");
        }

        private bool DocumentExists(int id)
        {
          return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
