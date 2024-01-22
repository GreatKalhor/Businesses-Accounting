using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ContactAddressInfoServices : BaseServices
    {

        public ContactAddressInfoServices() : base()
        {
        }
        public ContactAddressInfoServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
