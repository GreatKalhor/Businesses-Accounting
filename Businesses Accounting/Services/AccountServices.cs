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
            return db.Accounts.Where(c => c.ParentId == null).Include(z => z.InverseParent).ThenInclude(z => z.InverseParent).ThenInclude(z => z.InverseParent).ThenInclude(z => z.InverseParent).Select(x => new ItemViewModel(x, false)).ToList();
        }
        public List<ItemViewModel> GetAccountsForTreeflat()
        {
            return db.Accounts.Include(z => z.InverseParent).ThenInclude(z => z.InverseParent).ThenInclude(z => z.InverseParent).ThenInclude(z => z.InverseParent).Select(x => new ItemViewModel(x, true)).ToList();
        }
        public string GetAccountsTextFromParents(int id)
        {
            string ans = "";
            var item = db.Accounts.Where(c => c.Id == id).Include(z => z.Parent).ThenInclude(z => z.Parent).ThenInclude(z => z.Parent).ThenInclude(z => z.Parent).ThenInclude(z => z.Parent).FirstOrDefault();
            if (item != null)
            {
                ans = txt(item);
            }
            return ans;
        }
        string txt(Account a)
        {
            string ans = a.Name;
            if (a.ParentId != null)
            {
                ans = $"{txt(a.Parent)} - {ans}";
            }
            return ans;
        }
    }
}
