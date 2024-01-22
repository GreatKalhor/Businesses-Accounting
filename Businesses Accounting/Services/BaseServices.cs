using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BaseServices : IDisposable
    {
        private bool disposedValue;
        private bool ignorDisposeddb { get; set; }
        public BA_dbContext db { get; }
        public BaseServices()
        {
            db = new BA_dbContext();
        }
        public BaseServices(BA_dbContext dbContext)
        {
            ignorDisposeddb = true;
            db = dbContext;
        }








        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (!ignorDisposeddb)
                    {
                        db.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
