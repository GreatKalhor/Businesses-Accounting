using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ProductPriceListServices : BaseServices
    {

        public ProductPriceListServices() : base()
        {
        }
        public ProductPriceListServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
