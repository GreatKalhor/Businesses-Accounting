using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessFiscalYearServices : BaseServices
    {

        public BusinessFiscalYearServices() : base()
        {
        }
        public BusinessFiscalYearServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public async Task<BusinessFiscalYear?> GetWithBusinessId(int businessId)
        {
            return await db.BusinessFiscalYears.FirstOrDefaultAsync(x => x.BusinessId == businessId);
        }
    }
}
