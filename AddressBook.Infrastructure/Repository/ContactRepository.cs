using AddressBook.Application.ApplicationModels.Repositories;
using AddressBook.Domain.Entities;
using AddressBook.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repository
{
    public class ContactRepository : IRepository
    {

        private ContactsContext _bookContext;
        public ContactRepository(ContactsContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task CreateAsync(Contact entity)
        {
            try
            {

                _bookContext.Contacts.Add(entity);
                await _bookContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("There are incorrectly entered values");
            }
        }

        public async Task DeleteAsync(int Id)
        {
            _bookContext.Contacts.Remove(_bookContext.Contacts.Find(Id));
            await _bookContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> ReadAllAsync()
        {
            var task = _bookContext.Contacts.ToListAsync();
            var allContacts = await task;
            return allContacts;
        }
        public async Task<Contact> ReadByIdAsync(int Id)
        {
            var task = _bookContext.Contacts.Where(m => m.Id == Id).FirstOrDefaultAsync();
            var contact = await task;
            return contact;
        }

        public async Task UpdateAsync(Contact entity)
        {
            try
            {
                var contact = _bookContext.Contacts.FirstOrDefault(c => c.Id == entity.Id);
                contact.EmailAddress = entity.EmailAddress;
                contact.FullName = entity.FullName;
                contact.PhoneNumber = entity.PhoneNumber;
                contact.PhysicalAddress = entity.PhysicalAddress;
                await _bookContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("These changes can not be saved as there is a breach of validity");
            }
        }
    }
}
