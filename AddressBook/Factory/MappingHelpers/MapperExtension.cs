﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Factory.MappingHelpers
{
    public class MapperExtension
    {
        public static TDestination MapTo<TDestination>(object mappable)
        {
            TDestination value = AutoMapperConfig.CreateInstance().Map<TDestination>(mappable);
            return value;
        }
    }
}