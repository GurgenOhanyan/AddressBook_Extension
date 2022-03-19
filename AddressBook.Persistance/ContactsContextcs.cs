using AddressBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddressBook.Persistance
{
    public class ContactsContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Contact> Contacts { get; set; }
        public ContactsContext(string conectionString)
        {
            Database.Connection.ConnectionString = conectionString;
            if (!Database.Exists())
            {
                Database.Create();
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .Property(p => p.PhysicalAddress).HasMaxLength(40);
        }
    }
}

