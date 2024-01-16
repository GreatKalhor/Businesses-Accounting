using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessFiscalYearServices : IDisposable
    {
        private bool disposedValue;
        private bool ignorDisposeddb { get; set; }
        BA_dbContext db { get; }
        public BusinessFiscalYearServices()
        {
            db = new BA_dbContext();
        }
        public BusinessFiscalYearServices(BA_dbContext dbContext)
        {
            ignorDisposeddb = true;
            db = dbContext;
        }


        public async Task<BusinessFiscalYear?> GetWithBusinessId(int businessId)
        {
            return await db.BusinessFiscalYears.FirstOrDefaultAsync(x => x.BusinessId == businessId);
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
