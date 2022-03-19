using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Factory.MappingHelpers
{
    public static class AutoMapperConfig
    {
        private static Mapper _mapper;
        public static Mapper CreateInstance()
        {
            if (_mapper == null)
            {
                Register();
            }
            return _mapper;
        }
        private static void Register()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Models.Contact, Application.ApplicationModels.Contact>();
                c.CreateMap<Application.ApplicationModels.Contact, Models.Contact>();
            });
            _mapper = new Mapper(config);
        }

    }
}