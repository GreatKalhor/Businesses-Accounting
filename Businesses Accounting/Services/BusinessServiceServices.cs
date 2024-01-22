using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessServiceServices : BaseServices
    {

        public BusinessServiceServices() : base()
        {
        }
        public BusinessServiceServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
