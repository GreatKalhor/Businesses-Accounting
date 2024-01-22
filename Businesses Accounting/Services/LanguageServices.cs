using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services

{
    public class LanguageServices : BaseServices
    {

        public LanguageServices() : base()
        {
        }
        public LanguageServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public int DefaultId()
        {
            var l = db.Languages.FirstOrDefault(x => x.Name == "فارسی");
            return l != null ? l.Id : 0;
        }
    }
}
