using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Businesses_Accounting.Resources.Variable;

namespace Businesses_Accounting.Services
{
    public class BusinessServices :BaseServices
    {
      
        public BusinessServices() : base()
    {
    }
    public BusinessServices(BA_dbContext dbContext) : base(dbContext)
    {
    }


    public async Task InsertBusiness(Business business, Guid? userId)
        {
            if (userId is not null)
            {
                db.Add(business);
                await db.SaveChangesAsync();
                if (business.Id > 0)
                {
                    db.Add(new BusinessUser() { BusinessId = business.Id, UserId = userId.Value, AccessTypeId = (int)Resources.Variable.AccessType.Owner });
                    db.Add(new BusinessFiscalYear() { BusinessId = business.Id, Title = "پیش فرض", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3), InventoryValuationMethod = 1 });
                    await db.SaveChangesAsync();
                }
            }
        }
        public async Task<int> InsertBusiness(CreateBusinessViewModel business, Guid? userId)
        {
            int id = 0;
            if (userId is not null)
            {
                var _b = new Business() { Name = business.Name, LanguageId = business.LanguageId, LegalName = business.LegalName, TypeId = business.TypeId };
                db.Add(_b);
                await db.SaveChangesAsync();
                if (_b.Id > 0)
                {
                    id = _b.Id;
                    db.Add(new BusinessUser() { BusinessId = _b.Id, UserId = userId.Value, AccessTypeId = (int)Resources.Variable.AccessType.Owner });
                    db.Add(new BusinessFiscalYear() { BusinessId = _b.Id, Title = "پیش فرض", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3), InventoryValuationMethod = 1 });
                    db.Add(new BusinessFinancialInfo() { BusinessId = _b.Id, InventoryAccountingSystem = business.InventoryAccountingSystem, CalendarId = business.CalendarId, MainCurrencyId = business.MainCurrencyId, ValueAddedTaxRate = business.ValueAddedTaxRate, HasMultiCurrency = business.HasMultiCurrency, HasWarehouseManagement = business.HasWarehouseManagement });
                    db.Add(new BusinessCurrencyConversion() { BusinessId = _b.Id, CurrencyId = business.MainCurrencyId, MainValue = business.MainCurrencyId });
                    foreach (var item in business.CurrenciesIds)
                    {
                        db.Add(new BusinessCurrencyConversion() { BusinessId = _b.Id, CurrencyId = item, MainValue = business.MainCurrencyId });
                    }
                    foreach (var item in PanelServices.GetEnumAllValues<CategoryType>())
                    {
                        db.Add(new BusinessCategory() { BusinessId = _b.Id, Title = item.GetDescription(), CategoryType = item.ToInt() });
                    }
                    await db.SaveChangesAsync();
                }
            }
            return id;
        }
        public async Task<List<Business>> GetBusinessWithUser(Guid? userId)
        {
            if (userId is not null)
            {
                var bA_dbContext = db.BusinessUsers.Where(x => x.UserId == userId.Value).Include(b => b.Business)
                    .Select(f => f.Business);
                var ans = await bA_dbContext.ToListAsync();
                return ans;
            }
            else
            {
                return new List<Business>();
            }
        }

        public async Task<Business?> FindAsync(int id)
        {
            return await db.Businesses.FindAsync(id);
        }


    }
}
