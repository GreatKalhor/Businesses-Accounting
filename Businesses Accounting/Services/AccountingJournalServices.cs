using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class AccountingJournalServices : BaseServices
    {
      
        public AccountingJournalServices():base()
        {
        }
        public AccountingJournalServices(BA_dbContext dbContext):base(dbContext)
        {   
        }
       
    }
}
