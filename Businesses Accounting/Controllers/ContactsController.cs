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
using static Businesses_Accounting.Resources.Variable;
using Businesses_Accounting.Helper;
using Elfie.Serialization;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]
    public class ContactsController : GreatController
    {
        private readonly BA_dbContext _context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public ContactsController(BA_dbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            Environment = _environment;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }
        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            using (ContactServices cs = new ContactServices(_context))
            {
                var userpanel = PanelUser;
                var result = cs.GetContactsWithBusinessId(userpanel.BusinessId);
                var dsResult = result.ToDataSourceResult(request);
                return Json(dsResult);
            }
        }

        public IActionResult Create()
        {
            using (BusinessCategoryServices bcs = new BusinessCategoryServices())
            {
                var userpanel = PanelUser;
                var ci = bcs.GetCategoriesWithBusinessId(userpanel.BusinessId, CategoryType.Contact).FirstOrDefault()?.Id;
                return View(new CreateContactViewModel() { BusinessId = userpanel.BusinessId, CategoryId = (ci != null ? ci.Value : 0) });

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContactViewModel contact)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (ContactServices cs = new ContactServices(_context))
                    {
                        var filenames = FileHelper.SaveFiles(contact.files, Environment, "Contacts");
                        if (filenames.Count > 0)
                        {
                            contact.ImageUrl = filenames[0];
                        }
                        contact.BusinessId = PanelUser.BusinessId;
                        await cs.InsertContactAsync(contact);
                        return RedirectToAction("Index", "Contacts");
                    }
                }
                return View(contact);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (ContactServices cs = new ContactServices(_context))
            {
                var contact = await cs.FindAsync(id.Value);
                if (contact == null || contact.BusinessId != PanelUser.BusinessId)
                {
                    return NotFound();
                }
                return View(contact);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateContactViewModel contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var filenames = FileHelper.SaveFiles(contact.files, Environment, "Contacts");
                if (filenames.Count > 0)
                {
                    contact.ImageUrl = filenames[0];
                }
                using (ContactServices cs = new ContactServices(_context))
                {
                    contact.BusinessId = PanelUser.BusinessId;
                    await cs.UpdateContactAsync(contact);
                }
                return RedirectToAction("Index", "Contacts");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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
            return RedirectToAction("Index", "Contacts");
        }

        private bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
