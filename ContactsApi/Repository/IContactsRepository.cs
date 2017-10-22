using ContactsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApi.Repository
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Find(int id);
        Task Add(Contact item);
        Task Update(Contact oldContact, Contact newContact);
        Task Remove(Contact itemToRemove);
    }
}
