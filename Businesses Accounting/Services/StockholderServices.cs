using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class StockholderServices : BaseServices
    {

        public StockholderServices() : base()
        {
        }
        public StockholderServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
