using AddressBook.Application.ApplicationModels;
using AddressBook.Application.ApplicationModels.Repositories;
using AddressBook.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Servicies
{
    public class ContactService : IContactService
    {
        private IRepository _repository;
        public ContactService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(Application.ApplicationModels.Contact appContact)
        {
            var domainContact = MappingHelpers.MapperExtension.MapTo<Domain.Entities.Contact>(appContact);

            await _repository.CreateAsync(domainContact);
        }

        public async Task DeleteContact(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task EditContact(Application.ApplicationModels.Contact appContact)
        {
            var domainModel = MappingHelpers.MapperExtension.MapTo<Domain.Entities.Contact>(appContact);
            await _repository.UpdateAsync(domainModel);
        }

        public async Task<List<Application.ApplicationModels.Contact>> GetAll()
        {
            var task = _repository.ReadAllAsync();
            var domainContacts = await task;
            var appContacts = domainContacts.Select(c => MappingHelpers.MapperExtension.MapTo<Application
                                                                 .ApplicationModels.Contact>(c)).ToList();
            return appContacts;
        }

        public async Task<Application.ApplicationModels.Contact> GetSingle(int Id)
        {
            var task = _repository.ReadByIdAsync(Id);
            var domainContact = await task;
            var appContact = MappingHelpers.MapperExtension.MapTo<Application.ApplicationModels.Contact>(domainContact);
            return appContact;
        }
    }
}
