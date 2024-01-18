using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Businesses_Accounting.Models.ViewModels
{
    public class CreateBusinessViewModel
    {
        public CreateBusinessViewModel()
        {
            CurrenciesIds = new Collection<int>();
        }
        public int Id { get; set; }
        [Display(Name = "نام کسب و کار")]
        public string Name { get; set; }
        [Display(Name = "زبان")]
        public int LanguageId { get; set; } = 1;
        [Display(Name = "نام قانونی")]
        public string LegalName { get; set; }
        [Display(Name = "نوع کسب و کار")]
        public int TypeId { get; set; } = 1;
        [Display(Name = "سیستم حسابداری انبار")]
        public int InventoryAccountingSystem { get; set; }
        [Display(Name = "امکان استفاده از سیستم چند ارزی")]
        public bool HasMultiCurrency { get; set; } = true;
        [Display(Name = "امکان استفاده از سیستم انبارداری")]
        public bool HasWarehouseManagement { get; set; }
        [Display(Name = "واحد پول اصلی")]
        public int MainCurrencyId { get; set; } = 1;
        [Display(Name = "تقویم")]
        public int CalendarId { get; set; } = 1;
        [Display(Name = "نرخ مالیات ارزش افزوده")]
        public int ValueAddedTaxRate { get; set; }
        [Display(Name = "سایر ارزها ")]
        public Collection<int> CurrenciesIds { get; set; }

    }
}
