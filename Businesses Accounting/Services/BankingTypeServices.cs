using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BankingTypeServices : BaseServices
    {

        public BankingTypeServices() : base()
        {
        }
        public BankingTypeServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
