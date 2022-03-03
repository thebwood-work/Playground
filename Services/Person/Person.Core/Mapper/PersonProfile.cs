using AutoMapper;
using Person.Core.Models;
using Person.Infrastructure.Entities;

namespace Person.Core.Mapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<People, PersonModel>();
            CreateMap<PersonModel, People>();
        }
    }
}
