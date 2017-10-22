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

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> Find(int id)
        {
            return await _context.Contacts
                .Where(e => e.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task Add(Contact item)
        {
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contact oldContact, Contact newContact)
        {
            oldContact.FirstName = newContact.FirstName;
            oldContact.LastName = newContact.LastName;
            oldContact.IsFamilyMember = newContact.IsFamilyMember;
            oldContact.Company = newContact.Company;
            oldContact.JobTitle = newContact.JobTitle;
            oldContact.Email = newContact.Email;
            oldContact.MobilePhone = newContact.MobilePhone;
            oldContact.DateOfBirth = newContact.DateOfBirth;
            oldContact.AnniversaryDate = newContact.AnniversaryDate;
            await _context.SaveChangesAsync();
            
        }

        public async Task Remove(Contact itemToRemove)
        {
            _context.Contacts.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    }
}
