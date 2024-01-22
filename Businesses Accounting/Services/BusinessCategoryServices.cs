using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessCategoryServices : BaseServices
    {

        public BusinessCategoryServices() : base()
        {
        }
        public BusinessCategoryServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
