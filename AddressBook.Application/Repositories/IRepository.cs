using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.ApplicationModels.Repositories
{
    public interface IRepository
    {
        Task<List<Domain.Entities.Contact>> ReadAllAsync();
        Task<Domain.Entities.Contact> ReadByIdAsync(int Id);
        Task CreateAsync(Domain.Entities.Contact entity);
        Task UpdateAsync(Domain.Entities.Contact entity);
        Task DeleteAsync(int entity);
    }
}
