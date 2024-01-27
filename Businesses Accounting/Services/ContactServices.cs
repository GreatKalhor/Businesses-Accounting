using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static Businesses_Accounting.Resources.Variable;

namespace Businesses_Accounting.Services
{
    public class ContactServices : BaseServices
    {

        public ContactServices() : base()
        {
        }
        public ContactServices(BA_dbContext dbContext) : base(dbContext)
        {
        }

        public List<Contact> GetContactsWithBusinessId(int businessId)
        {
            List<Contact> ans = new List<Contact>();
            var list = db.Contacts.Where(x => x.BusinessId == businessId);
            if (list != null && list.Any())
            {
                ans.AddRange(list);
            }
            return ans;
        }
        public async Task<Contact?> FindAsync(int id)
        {
            return await db.Contacts.FindAsync(id);
        }
        public Contact? Find(int id)
        {
            return db.Contacts.Find(id);
        }
        public async Task InsertContactAsync(CreateContactViewModel contact)
        {
            var _contact = contact.ToContact();
            db.Add(_contact);
            await db.SaveChangesAsync();
            using (SubAccountServices sas = new SubAccountServices(db))
            {
                await sas.InsertSubAccountAsync(contact.BusinessId, _contact.Id, ObjectType.Contact);
            }
        }
        public async Task UpdateContactAsync(CreateContactViewModel contact)
        {
            var _c = db.Contacts.Where(x => x.Id == contact.Id && x.BusinessId == contact.BusinessId);
            if (_c != null)
            {
                db.Update(contact.ToContact());
                await db.SaveChangesAsync();
            }
        }

    }
}
