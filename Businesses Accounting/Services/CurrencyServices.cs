using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class CurrencyServices : BaseServices
    {

        public CurrencyServices() : base()
        {
        }
        public CurrencyServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public int DefaultId()
        {
            var c = db.Currencies.Where(x => x.Name.Contains("IRR")).FirstOrDefault();
            return c != null ? c.Id : 0;
        }
    }
}
