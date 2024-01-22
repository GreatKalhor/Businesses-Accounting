using Businesses_Accounting.Data;
using Businesses_Accounting.Models;

namespace Businesses_Accounting.Services
{
    public class UserService : BaseServices
    {

        public UserService() : base()
        {
        }
        public UserService(BA_dbContext dbContext) : base(dbContext)
        {
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
        public async Task UpdateUser(AspNetUser user)
        {
            db.AspNetUsers.Update(user);
            await db.SaveChangesAsync();
        }
        
    }
}
