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

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    public class BusinessesController : Controller
    {
        private readonly BA_dbContext _context;

        public BusinessesController(BA_dbContext context)
        {
            _context = context;
        }

        // GET: Businesses
        public async Task<IActionResult> Index()
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                return View(await bs.GetBusinessWithUser(CurrentUser.GetUserId(User)));
            }
        }
        public IActionResult DetailProducts_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json("");
        }

        [AcceptVerbs("Post")]
        public ActionResult BusinessesList(DataSourceRequest request)
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                var result = bs.GetBusinessWithUser(CurrentUser.GetUserId(User)).Result;
                var dsResult = result.ToDataSourceResult(request);
                return Json(dsResult);
            }
        }

        // GET: Businesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses
                .Include(b => b.Language)
                .Include(b => b.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // GET: Businesses/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Languages, "Id", "Flag");
            ViewData["TypeId"] = new SelectList(_context.BusinessTypes, "Id", "Name");
            return View(new Business());
        }
        public JsonResult Items_GetLanguages(string text)
        {

            var languages = _context.Languages.Select(x => x);

            if (!string.IsNullOrEmpty(text))
            {
                languages = languages.Where(p => p.Name.Contains(text));
            }

            return Json(languages.ToList());
        }
        public JsonResult Items_GetBusinessTypes(string text)
        {

            var businessTypes = _context.BusinessTypes.Select(x => x);

            if (!string.IsNullOrEmpty(text))
            {
                businessTypes = businessTypes.Where(p => p.Name.Contains(text));
            }

            return Json(businessTypes.ToList());
        }
        // POST: Businesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Business business)
        {
            if (ModelState.IsValid)
            {
                using (BusinessServices bs = new BusinessServices(_context))
                {
                    await bs.InsertBusiness(business, CurrentUser.GetUserId(User));
                }
                //_context.Add(business);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(business);
        }

        // GET: Businesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Flag", business.LanguageId);
            ViewData["TypeId"] = new SelectList(_context.BusinessTypes, "Id", "Name", business.TypeId);
            return View(business);
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LanguageId,LegalName,TypeId,BusinessLine,NationalCode,EconomicCode,RegistrationNumber,Country,StateProvince,City,PostalCode,Phone,Fax,Address,Website,Email,LogoUrl")] Business business)
        {
            if (id != business.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.Id))
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
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Flag", business.LanguageId);
            ViewData["TypeId"] = new SelectList(_context.BusinessTypes, "Id", "Name", business.TypeId);
            return View(business);
        }

        // GET: Businesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses
                .Include(b => b.Language)
                .Include(b => b.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // POST: Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Businesses == null)
            {
                return Problem("Entity set 'BA_dbContext.Businesses'  is null.");
            }
            var business = await _context.Businesses.FindAsync(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(int id)
        {
            return (_context.Businesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
