using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Businesses_Accounting.Services
{
    public class BusinessServices : IDisposable
    {
        private bool disposedValue;
        private bool ignorDisposeddb { get; set; }
        BA_dbContext db { get; }
        public BusinessServices()
        {
            db = new BA_dbContext();
        }
        public BusinessServices(BA_dbContext dbContext)
        {
            ignorDisposeddb = true;
            db = dbContext;
        }


        public async Task InsertBusiness(Business business, Guid? userId)
        {
            if (userId is not null)
            {
                db.Add(business);
                await db.SaveChangesAsync();
                if (business.Id > 0)
                {
                    db.Add(new BusinessUser() { BusinessId = business.Id, UserId = userId.Value, AccessTypeId = (int)Resources.Variable.AccessType.Owner });
                    db.Add(new BusinessFiscalYear() { BusinessId = business.Id, Title = "پیش فرض", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3), InventoryValuationMethod = 1 });
                    await db.SaveChangesAsync();
                }
            }
        }
        public async Task<List<Business>> GetBusinessWithUser(Guid? userId)
        {
            if (userId is not null)
            {
                var bA_dbContext = db.BusinessUsers.Where(x => x.UserId == userId.Value).Include(b => b.Business)
                    //.Include(b => b.Business.Language).Include(b => b.Business.Type)
                    .Select(f => f.Business);
                var ans = await bA_dbContext.ToListAsync();
                return ans;
            }
            else
            {
                return new List<Business>();
            }
        }

        public async Task<Business?> FindAsync(int id)
        {
            return await db.Businesses.FindAsync(id);
        }





        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (!ignorDisposeddb)
                    {
                        db.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BusinessServices()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
