using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class ContactServices : BaseServices
    {

        public ContactServices() : base()
        {
        }
        public ContactServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
