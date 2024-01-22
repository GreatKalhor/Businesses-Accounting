using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class DocumentServices : BaseServices
    {

        public DocumentServices() : base()
        {
        }
        public DocumentServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
