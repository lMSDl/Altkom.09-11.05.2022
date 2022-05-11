using AutoMapper;
using DAL.dbFirst;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.dbFIrst
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new EFCContext();
            var people = context.People.ToList();

            var mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<DAL.dbFirst.Person, Models.Person>().ForMember(x => x.FirstName, x => x.MapFrom(xx => xx.Name));
                x.CreateMap<Models.Person, DAL.dbFirst.Person>().ForMember(x => x.Name, x => x.MapFrom(xx => xx.FirstName));
            }).CreateMapper();

            var modelsPeople = mapper.Map<IEnumerable<Models.Person>>(people);
        }
    }
}
