using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Businesses_Accounting.Models.ViewModels
{
    public class CreateBusinessViewModel
    {
        public CreateBusinessViewModel()
        {
            CurrenciesIds = new List<int>();
            files = new List<IFormFile>();
        }
        public CreateBusinessViewModel(Business b)
        {
            CurrenciesIds = new List<int>();
            files = new List<IFormFile>();
            if (b is not null)
            {
                Name = b.Name;
                Id = b.Id;
                LanguageId = b.LanguageId;
                LegalName = b.LegalName;
                TypeId = b.TypeId;
                ImageUrl = b.LogoUrl;
                var _BusinessFinancialInfos = b.BusinessFinancialInfos.FirstOrDefault();
                if (_BusinessFinancialInfos != null)
                {
                    InventoryAccountingSystem = _BusinessFinancialInfos.InventoryAccountingSystem;
                    HasMultiCurrency = _BusinessFinancialInfos.HasMultiCurrency;
                    HasWarehouseManagement = _BusinessFinancialInfos.HasWarehouseManagement;
                    MainCurrencyId = _BusinessFinancialInfos.MainCurrencyId;
                    CalendarId = _BusinessFinancialInfos.CalendarId;
                    ValueAddedTaxRate = _BusinessFinancialInfos.ValueAddedTaxRate;
                }
                var _Currencies = b.BusinessCurrencyConversions;
                if (_Currencies != null)
                {
                    CurrenciesIds.AddRange(_Currencies.Select(x => x.CurrencyId).Where(x => x != MainCurrencyId));
                }
            }


        }
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "زبان")]
        public int LanguageId { get; set; } = 1;
        [Display(Name = "نام قانونی")]
        public string LegalName { get; set; } = " ";
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
        public List<int>? CurrenciesIds { get; set; }

        public string? ImageUrl { get; set; }
        public IEnumerable<IFormFile> files { get; set; }
    }
}
