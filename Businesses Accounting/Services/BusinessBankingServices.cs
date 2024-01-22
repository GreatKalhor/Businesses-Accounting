using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessBankingServices : BaseServices
    {

        public BusinessBankingServices() : base()
        {
        }
        public BusinessBankingServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
