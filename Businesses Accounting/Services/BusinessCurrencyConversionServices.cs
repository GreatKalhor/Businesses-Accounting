using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Businesses_Accounting.Services
{
    public class BusinessCurrencyConversionServices : BaseServices
    {

        public BusinessCurrencyConversionServices() : base()
        {
        }
        public BusinessCurrencyConversionServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
       
        public async Task<List<BusinessCurrencyConversion>> GetBusinessCurrencyConversionWithBusinessId(int businessId)
        {
           return await db.BusinessCurrencyConversions.Where(x => x.BusinessId == businessId).ToListAsync();
        }
        public async Task InsertWithIds(int businessId,IEnumerable<int> ids,int mainval)
        {
            foreach (var item in ids)
            {
                db.Add(new BusinessCurrencyConversion() { BusinessId = businessId, CurrencyId = item, MainValue = mainval });
            }
            await db.SaveChangesAsync();
        }
        public async Task DeleteWithIds(int businessId, IEnumerable<int> ids)
        {
            db.BusinessCurrencyConversions.RemoveRange(db.BusinessCurrencyConversions.Where(x => x.BusinessId == businessId && ids.Contains(x.CurrencyId)));
            await db.SaveChangesAsync();
        }
        public async Task UpdateBusinessCurrencyConversion(BusinessCurrencyConversion bcc)
        {
            db.BusinessCurrencyConversions.Update(bcc);
           await db.SaveChangesAsync();
        }
    }
}
