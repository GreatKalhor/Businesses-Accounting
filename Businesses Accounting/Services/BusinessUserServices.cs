using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessUserServices : BaseServices
    {

        public BusinessUserServices() : base()
        {
        }
        public BusinessUserServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
