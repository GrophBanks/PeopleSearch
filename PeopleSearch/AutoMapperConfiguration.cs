using AutoMapper;
using PeopleSearch.Entity;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.CreateMap<AddPersonModel, Person>().ForMember(p => p.PersonId, opt => opt.Ignore()));
        }
    }
}