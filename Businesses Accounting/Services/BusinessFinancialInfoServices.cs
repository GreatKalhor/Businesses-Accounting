using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessFinancialInfoServices : BaseServices
    {

        public BusinessFinancialInfoServices() : base()
        {
        }
        public BusinessFinancialInfoServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public BusinessFinancialInfo FindWithBusinessId(int businessid)
        {
            return db.BusinessFinancialInfos.FirstOrDefault(c => c.BusinessId == businessid);
        }
        public async Task<BusinessFinancialInfo> FindWithBusinessIdAsync(int businessid)
        {
            return await db.BusinessFinancialInfos.FirstOrDefaultAsync(c => c.BusinessId == businessid);
        }

        public async Task UpdateBusinessFinancialInfo(BusinessFinancialInfo bfi)
        {
             db.BusinessFinancialInfos.Update(bfi);
            await db.SaveChangesAsync();
        }
    }
}
