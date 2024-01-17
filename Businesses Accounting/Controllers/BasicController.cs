using Businesses_Accounting.Data;
using Businesses_Accounting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Businesses_Accounting.Resources.Variable;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    public class BasicController : Controller
    {

        private readonly BA_dbContext _context;

        public BasicController(BA_dbContext context)
        {
            _context = context;
        }

        public JsonResult Items_GetLanguages(string text)
        {
            var languages = _context.Languages.Select(x => x);
            return Json(languages.Where(p => p.Name.Contains(text ?? "")).ToList());
        }
        public JsonResult Items_GetCurrency(string text)
        {
            var currencies = _context.Currencies.Select(x => x);
            return Json(currencies.Where(p => p.Name.Contains(text ?? "")).ToList());
        }
        public JsonResult Items_GetCurrencies()
        {
            return Json(new SelectList(_context.Currencies, "Id", "Name"));
        }
        public JsonResult Items_GetBusinessTypes(string text)
        {
            var businessTypes = _context.BusinessTypes.Select(x => x);
            return Json(businessTypes.Where(p => p.Name.Contains(text ?? "")).ToList());
        }
        public JsonResult Items_GetCalendars(string text)
        {
            return Json(PanelServices.EnumToSelectListItem<CalendarType>().Where(x=>x.Text.Contains(text??"")).ToList());
        }
    }
}
