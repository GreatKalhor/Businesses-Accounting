using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class AccountServices : BaseServices
    {

        public AccountServices() : base()
        {
        }
        public AccountServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
