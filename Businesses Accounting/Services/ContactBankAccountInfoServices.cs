using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ContactBankAccountInfoServices : BaseServices
    {

        public ContactBankAccountInfoServices() : base()
        {
        }
        public ContactBankAccountInfoServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
