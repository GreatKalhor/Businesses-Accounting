using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using static Businesses_Accounting.Resources.Variable;

namespace Businesses_Accounting.Services
{
    public class SubAccountServices : BaseServices
    {

        public SubAccountServices() : base()
        {
        }
        public SubAccountServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
        public async Task InsertSubAccountAsync(int businessId, int objId, ObjectType objectType)
        {
            db.Add(new SubAccount() {Name=" ", BusinessId = businessId, ObjetcId = objId, ObjetcType = ((int)objectType) });
            await db.SaveChangesAsync();
        }
        public void InsertSubAccount(int businessId, int objId, ObjectType objectType)
        {
            db.Add(new SubAccount() { Name =" ", BusinessId = businessId, ObjetcId = objId, ObjetcType = ((int)objectType) });
            db.SaveChangesAsync();
        }
    }
}
