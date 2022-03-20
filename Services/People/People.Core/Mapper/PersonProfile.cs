using AutoMapper;
using People.Core.Models;
using People.Infrastructure.Entities;

namespace People.Core.Mapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonModel>();
            CreateMap<PersonModel, Person>();
            CreateMap<PersonSearchModel, PersonSearch>();
            CreateMap<PersonSearchResults, PersonSearchResultsModel>();
        }
    }
}
