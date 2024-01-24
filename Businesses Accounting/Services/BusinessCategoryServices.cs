using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;
using static Businesses_Accounting.Resources.Variable;

namespace Businesses_Accounting.Services
{
    public class BusinessCategoryServices : BaseServices
    {

        public BusinessCategoryServices() : base()
        {
        }
        public BusinessCategoryServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public List<BusinessCategory> GetCategoriesWithBusinessId(int businessId)
        {
            return db.BusinessCategories.Where(v => v.BusinessId == businessId).ToList();
        }
        public List<BusinessCategory> GetCategoriesWithBusinessId(int businessId , CategoryType type)
        {
            return db.BusinessCategories.Where(v => v.BusinessId == businessId && v.CategoryType == (int)type).ToList();
        }
    }
}
