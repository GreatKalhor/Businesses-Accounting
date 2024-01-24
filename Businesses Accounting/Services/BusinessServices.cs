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
    public class BusinessServices : BaseServices
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
                var _b = new Business() { Name = business.Name, LanguageId = business.LanguageId, LegalName = business.LegalName, TypeId = business.TypeId, LogoUrl = business.ImageUrl };
                db.Add(_b);
                await db.SaveChangesAsync();
                if (_b.Id > 0)
                {
                    id = _b.Id;
                    db.Add(new BusinessUser() { BusinessId = _b.Id, UserId = userId.Value, AccessTypeId = (int)Resources.Variable.AccessType.Owner });
                    db.Add(new BusinessFiscalYear() { BusinessId = _b.Id, Title = "پیش فرض", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3), InventoryValuationMethod = 1 });
                    db.Add(new BusinessFinancialInfo() { BusinessId = _b.Id, InventoryAccountingSystem = business.InventoryAccountingSystem, CalendarId = business.CalendarId, MainCurrencyId = business.MainCurrencyId, ValueAddedTaxRate = business.ValueAddedTaxRate, HasMultiCurrency = business.HasMultiCurrency, HasWarehouseManagement = business.HasWarehouseManagement });
                    using (BusinessCurrencyConversionServices bccs = new BusinessCurrencyConversionServices(db))
                    {
                        var list = new List<int>();
                        list.Add(business.MainCurrencyId);
                        list.AddRange(business.CurrenciesIds);
                        await bccs.InsertWithIds(_b.Id, list, 1);
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
        public async Task UpdateBusiness(CreateBusinessViewModel business, Guid? userId)
        {
            var _bs = await GetBusinessWithUser(userId);
            if (_bs != null)
            {
                var _b = _bs.FirstOrDefault(x => x.Id == business.Id);
                if (_b != null)
                {
                    _b.Name = business.Name;
                    _b.LanguageId = business.LanguageId;
                    _b.LegalName = business.LegalName;
                    _b.TypeId = business.TypeId;
                    _b.LogoUrl = business.ImageUrl;
                    db.Businesses.Update(_b);
                    await db.SaveChangesAsync();

                    using (BusinessFinancialInfoServices bfis = new BusinessFinancialInfoServices(db))
                    {
                        var _bfi = await bfis.FindWithBusinessIdAsync(_b.Id);
                        if (_bfi != null)
                        {
                            _bfi.InventoryAccountingSystem = business.InventoryAccountingSystem;
                            _bfi.CalendarId = business.CalendarId;
                            _bfi.MainCurrencyId = business.MainCurrencyId;
                            _bfi.ValueAddedTaxRate = business.ValueAddedTaxRate;
                            _bfi.HasMultiCurrency = business.HasMultiCurrency;
                            _bfi.HasWarehouseManagement = business.HasWarehouseManagement;
                            await bfis.UpdateBusinessFinancialInfo(_bfi);
                        }

                    }

                    using (BusinessCurrencyConversionServices bccs = new BusinessCurrencyConversionServices())
                    {
                        var Currences = await bccs.GetBusinessCurrencyConversionWithBusinessId(_b.Id);
                        if (Currences != null)
                        {
                            List<int> delIds = new List<int>();
                            List<int> addIds = new List<int>();
                            if (business.CurrenciesIds != null && business.CurrenciesIds.Count > 0)
                            {
                                var _delIds = Currences.Where(x => x.CurrencyId != business.MainCurrencyId && !business.CurrenciesIds.Contains(x.CurrencyId));
                                if (_delIds.Any())
                                {
                                    delIds.AddRange(_delIds.Select(x => x.CurrencyId));
                                }
                                var _foradd = business.CurrenciesIds.Where(x => !Currences.Any(c => c.CurrencyId == x));
                                addIds.AddRange(_foradd);
                            }
                            else
                            {
                                delIds.AddRange(Currences.Where(x => x.CurrencyId != business.MainCurrencyId).Select(c => c.CurrencyId));
                            }

                            await bccs.InsertWithIds(_b.Id, addIds, 1);
                            await bccs.DeleteWithIds(_b.Id, delIds);
                        }

                    }

                }
            }
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
            return await db.Businesses.Where(x => x.Id == id).Include(x => x.Language).Include(x => x.BusinessFinancialInfos).Include(x => x.BusinessCurrencyConversions).FirstOrDefaultAsync();
        }
        public async Task<Business?> FindAsync(int id, Guid? userId)
        {
            var b = await db.Businesses.Where(x => x.Id == id).Include(x => x.BusinessUsers).Include(x => x.Language).Include(x => x.BusinessFinancialInfos).Include(x => x.BusinessCurrencyConversions).FirstOrDefaultAsync();
            if (b != null && b.BusinessUsers.Any(v => v.UserId == userId))
            {
                return b;
            }
            else { return null; }
        }
        public async Task DeleteBusiness(int id, Guid? userId)
        {
            try
            {
                var bus = await db.BusinessUsers.Where(x => x.UserId == userId.Value && x.AccessTypeId == ((int)AccessType.Owner) && x.BusinessId == id).Include(b => b.Business).ToListAsync();
                if (bus != null && bus.Count > 0)
                {
                    db.Businesses.Remove(bus.FirstOrDefault().Business);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
