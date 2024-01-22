using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessTypeServices : BaseServices
    {

        public BusinessTypeServices() : base()
        {
        }
        public BusinessTypeServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public List<BusinessType> GetAll()
        {
            return db.BusinessTypes.ToList();
        }
    }
}
