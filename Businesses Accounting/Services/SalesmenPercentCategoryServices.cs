using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class SalesmenPercentCategoryServices : BaseServices
    {

        public SalesmenPercentCategoryServices() : base()
        {
        }
        public SalesmenPercentCategoryServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
