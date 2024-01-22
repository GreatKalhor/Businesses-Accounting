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
            var c = db.Currencies.FirstOrDefault(x => x.Name.Contains("IRR"));
            return c != null ? c.Id : 0;
        }
        public List<Currency> GetBusinessCurrencies(int businessid, int mainCurrencyId)
        {
            return db.BusinessCurrencyConversions.Where(c => c.BusinessId == businessid).Include(c => c.Currency).Select(x => new Currency(x.Currency, (x.CurrencyId == mainCurrencyId))).ToList();
        }
        public List<Currency> GetBusinessCurrencies(int businessid)
        {
            int mainCurrencyId = 0;
            using (BusinessFinancialInfoServices bfs = new BusinessFinancialInfoServices(db))
            {
                var bf = bfs.FindWithBusinessId(businessid);
                if (bf != null) { mainCurrencyId = bf.MainCurrencyId; }
            }
            return GetBusinessCurrencies(businessid, mainCurrencyId);
        }
        public List<Currency> GetAll()
        {
            return db.Currencies.ToList();
        }
    }
}
