using Businesses_Accounting.Data;
using Businesses_Accounting.Models;

namespace Businesses_Accounting.Services
{
    public class UserService : IDisposable
    {
        private bool disposedValue;
        BA_dbContext db { get; }
        public UserService()
        {
            db = new BA_dbContext();
        }

        public AspNetUser GetUser(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                return db.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            }
            else
            {
                return null;
            }
        }
        public AspNetUser GetUser(Guid userid)
        {
            return db.AspNetUsers.FirstOrDefault(x => x.Id == userid);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
