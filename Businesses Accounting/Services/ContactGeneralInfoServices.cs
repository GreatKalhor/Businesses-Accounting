using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ContactGeneralInfoServices : BaseServices
    {

        public ContactGeneralInfoServices() : base()
        {
        }
        public ContactGeneralInfoServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
