using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ServicePriceListServices : BaseServices
    {

        public ServicePriceListServices() : base()
        {
        }
        public ServicePriceListServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
