using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Models.ViewModels;
using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;
using static Businesses_Accounting.Resources.Variable;
using static System.Net.Mime.MediaTypeNames;
using LanguageServices = Businesses_Accounting.Services.LanguageServices;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    public class BasicController : GreatController
    {

        private readonly BA_dbContext _context;
        public BasicController(BA_dbContext context)
        {
            _context = context;
        }
        public JsonResult ReadAccountsDropDownTree(int? id)
        {
            using (AccountServices _as = new AccountServices(_context))
            {
                return Json(_as.GetAccountsForTree());
            }
        }
        public JsonResult AccountsDropDownTree(int? id)
        {
            using (AccountServices _as = new AccountServices(_context))
            {
                return Json(_as.GetAccountsForTreeflat());
            }
        }
        public ActionResult AccountsText(int? id)
        {
            using (AccountServices _as = new AccountServices(_context))
            {
                return Json(id != null ? _as.GetAccountsTextFromParents(id.Value) : "");
            }
        }
        public JsonResult Items_GetLanguages(string text)
        {
            using (LanguageServices ls = new LanguageServices(_context))
            {
                var languages = ls.GetAll();
                return Json(languages.Where(p => p.Name.Contains(text ?? "")).ToList());
            }
        }
        public JsonResult Items_GetCurrency(string text)
        {
            using (CurrencyServices cs = new CurrencyServices(_context))
            {
                var currencies = cs.GetAll();
                return Json(currencies.Where(p => p.Name.Contains(text ?? "")).ToList());
            }
        }
        public JsonResult Items_GetMainCurrency(string text)
        {
            var ub = PanelUser;
            using (CurrencyServices cs = new CurrencyServices(_context))
            {
                var currencies = cs.GetBusinessCurrencies(ub.BusinessId);
                return Json(currencies.Where(p => p.Name.Contains(text ?? "")).ToList());
            }
        }
        public JsonResult Items_GetCurrencies()
        {
            using (CurrencyServices cs = new CurrencyServices(_context))
            {
                var currencies = cs.GetAll();
                return Json(new SelectList(currencies, "Id", "Name"));
            }
        }
        public JsonResult Items_GetContacts()
        {
            using (ContactServices cs = new ContactServices(_context))
            {
                var currencies = cs.GetContactsWithBusinessId(PanelUser.BusinessId);
                return Json(currencies.ToList());
            }
        }
        public JsonResult Items_GetBusinessTypes(string text)
        {
            using (BusinessTypeServices bts = new BusinessTypeServices(_context))
            {
                var businessTypes = bts.GetAll();
                return Json(businessTypes.Where(p => p.Name.Contains(text ?? "")).ToList());
            }
        }
        public JsonResult Items_BusinessCategories(string text)
        {
            var ub = PanelUser;
            using (BusinessCategoryServices bcs = new BusinessCategoryServices(_context))
            {
                var businessTypes = bcs.GetCategoriesWithBusinessId(ub.BusinessId);
                return Json(businessTypes.Where(p => p.Title.Contains(text ?? "")).ToList());
            }
        }
        public JsonResult Items_GetCalendars(string text)
        {
            return Json(PanelServices.EnumToSelectListItem<CalendarType>().Where(x => x.Text.Contains(text ?? "")).ToList());
        }
        public JsonResult Items_GetInventoryAccountingSystemTypes(string text)
        {
            return Json(PanelServices.EnumToSelectListItem<InventoryAccountingSystemType>().Where(x => x.Text.Contains(text ?? "")).ToList());
        }
        public JsonResult Items_CategoryType(string text)
        {
            return Json(PanelServices.EnumToSelectListItem<CategoryType>().Where(x => x.Text.Contains(text ?? "")).ToList());
        }
    }
}
