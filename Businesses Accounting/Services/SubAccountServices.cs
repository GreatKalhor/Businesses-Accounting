using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class SubAccountServices : BaseServices
    {

        public SubAccountServices() : base()
        {
        }
        public SubAccountServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
