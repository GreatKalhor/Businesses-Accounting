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
using Businesses_Accounting.Models.ViewModels;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class ContactsController : Controller
    {
        private readonly BA_dbContext _context;


        public ContactsController(BA_dbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var bA_dbContext = _context.Contacts.Include(c => c.Business).Include(c => c.Category);
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
        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Business)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            var userpanel = HttpContext.ToPanelViewModel();
            return View(new CreateContactViewModel() { BusinessId = userpanel.BusinessId ,
                Type = new CheckBoxGroupViewModel()
                {
                    Items = new List<Kendo.Mvc.UI.IInputGroupItem>()
        {
            new InputGroupItemModel ()
                {
                    Label = "مشتری",
                    Enabled = true,
                    Encoded = false,
                   // CssClass = "blue",
                    Value = "IsCustomer"
                },
            new InputGroupItemModel ()
                {
                    Label = "تامین کننده",
                    Enabled = true,
                    Encoded = false,
                   // CssClass = "blue",
                    Value = "IsVendor"
                },
           new InputGroupItemModel ()
    {
        Label = "سهامدار",
        Enabled = true,
        Encoded = false,
       // CssClass = "blue",
        Value = "IsStockholder"
    },new InputGroupItemModel ()
    {
        Label = "کارمند",
        Enabled = true,
        Encoded = false,
       // CssClass = "blue",
        Value = "Employee"
    },
        },
                    CheckBoxGroupValue = new string[] { "نوع" }
                }
            });
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", contact.BusinessId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", contact.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", contact.CategoryId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessId,IsActive,Company,Title,FirstName,LastName,DisplayName,CategoryId,ImageUrl,IsCustomer,IsVendor,IsStockholder,Employee")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "Id", "LegalName", contact.BusinessId);
            ViewData["CategoryId"] = new SelectList(_context.BusinessCategories, "Id", "Title", contact.CategoryId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Business)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'BA_dbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
