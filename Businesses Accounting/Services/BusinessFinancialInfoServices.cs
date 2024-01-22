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
    }
}
