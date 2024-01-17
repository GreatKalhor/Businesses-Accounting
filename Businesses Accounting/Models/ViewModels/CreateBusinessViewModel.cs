using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Businesses_Accounting.Models.ViewModels
{
    public class CreateBusinessViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام کسب و کار")]
        public string Name { get; set; }
        [Display(Name = "زبان")]
        public int LanguageId { get; set; }
        [Display(Name = "نام قانونی")]
        public string LegalName { get; set; }
        [Display(Name = "نوع کسب و کار")]
        public int TypeId { get; set; }
        [Display(Name = "سیستم حسابداری انبار")]
        public int InventoryAccountingSystem { get; set; }
        [Display(Name = "امکان استفاده از سیستم چند ارزی")]
        public bool HasMultiCurrency { get; set; }
        [Display(Name = "امکان استفاده از سیستم انبارداری")]
        public bool HasWarehouseManagement { get; set; }
        [Display(Name = "واحد پول اصلی")]
        public int MainCurrencyId { get; set; }
        [Display(Name = "تقویم")]
        public int CalendarId { get; set; } = 1;
        [Display(Name = "نرخ مالیات ارزش افزوده")]
        public int ValueAddedTaxRate { get; set; }

        public Collection<int> CurrenciesIds { get; set; }

    }
}
