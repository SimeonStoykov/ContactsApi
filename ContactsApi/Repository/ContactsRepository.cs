using ContactsApi.Contexts;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private ContactsContext _context;

        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }

        public async Task Add(Contact item)
        {
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> Find(string id)
        {
            return await _context.Contacts
                .Where(e => e.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task Remove(string Id)
        {
            var itemToRemove = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == Id);
            if (itemToRemove != null)
            {
                _context.Contacts.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Contact item)
        {
            var itemToUpdate = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
                await _context.SaveChangesAsync();
            }
        }
    }
}
