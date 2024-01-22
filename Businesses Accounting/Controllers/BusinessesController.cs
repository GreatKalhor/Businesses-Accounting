﻿using System;
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
using Businesses_Accounting.Models.ViewModels;
using Businesses_Accounting.Resources;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    public class BusinessesController : GreatController
    {
        private readonly BA_dbContext _context;

        public BusinessesController(BA_dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                return View(await bs.GetBusinessWithUser(CurrentUser.GetUserId(User)));
            }
        }
  

        [AcceptVerbs("Post")]
        public ActionResult List(DataSourceRequest request)
        {
            using (BusinessServices bs = new BusinessServices(_context))
            {
                var result = bs.GetBusinessWithUser(CurrentUser.GetUserId(User)).Result;
                var dsResult = result.ToDataSourceResult(request);
                return Json(dsResult);
            }
        }

        public IActionResult Create()
        {
            return View(new CreateBusinessViewModel() { LanguageId = (DefaultValues.LanguageId != 0 ? DefaultValues.LanguageId : 1), MainCurrencyId = (DefaultValues.CurrencyId != 0 ? DefaultValues.CurrencyId : 1) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBusinessViewModel business)
        {
            if (ModelState.IsValid)
            {
                using (BusinessServices bs = new BusinessServices(_context))
                {
                    int id = await bs.InsertBusiness(business, CurrentUser.GetUserId(User));
                    return RedirectToAction("Check", "Dashbord", new { area = "Panel", businessId = id });
                }
            }
            return View(business);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            Business? business;
            using (BusinessServices bs=new BusinessServices(_context))
            {
                business = await bs.FindAsync(id.Value);
            }
            if (business == null)
            {
                return NotFound();
            }

            return View(new CreateBusinessViewModel(business));
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateBusinessViewModel business)
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
                return RedirectToAction("Index", "Businesses");
            }
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
            return RedirectToAction("Index", "Businesses");
        }

        private bool BusinessExists(int id)
        {
            return (_context.Businesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
