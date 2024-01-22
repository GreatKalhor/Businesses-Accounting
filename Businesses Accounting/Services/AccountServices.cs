using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Models.ViewModels;
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
        public List<ItemViewModel> GetAccountsForTree()
        {
            return db.Accounts.Where(c => c.ParentId == null).Include(z => z.InverseParent).Select(x => new ItemViewModel(x)).ToList();

        }
    }
}
