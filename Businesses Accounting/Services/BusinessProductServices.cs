using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessProductServices : BaseServices
    {

        public BusinessProductServices() : base()
        {
        }
        public BusinessProductServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
