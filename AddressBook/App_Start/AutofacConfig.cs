using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AddressBook.Application.ApplicationModels.Repositories;
using AddressBook.Application.Services;
using AddressBook.Controllers;
using AddressBook.Factory;
using AddressBook.Infrastructure.Repository;
using AddressBook.Infrastructure.Servicies;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AddressBook.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnection"].ConnectionString;

            builder.RegisterType<ContactController>();
            builder.RegisterType<ContactFactory>().As<IContactFactory>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<ContactRepository>().As<IRepository>().InstancePerLifetimeScope();
            builder.Register(dbcontext => new Persistance.ContactsContext(connectionString)).InstancePerLifetimeScope();

            Container = builder.Build();
            return Container;
        }
    }
}