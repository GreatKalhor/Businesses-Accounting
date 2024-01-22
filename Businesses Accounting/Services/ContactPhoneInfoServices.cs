using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ContactPhoneInfoServices : BaseServices
    {

        public ContactPhoneInfoServices() : base()
        {
        }
        public ContactPhoneInfoServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
