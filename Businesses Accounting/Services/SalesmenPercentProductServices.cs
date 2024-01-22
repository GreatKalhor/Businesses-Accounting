using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class SalesmenPercentProductServices : BaseServices
    {

        public SalesmenPercentProductServices() : base()
        {
        }
        public SalesmenPercentProductServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
