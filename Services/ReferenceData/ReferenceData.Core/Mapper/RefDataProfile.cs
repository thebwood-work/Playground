using AutoMapper;
using ReferenceData.Core.Models;
using ReferenceData.Infrastructure.Entities;

namespace ReferenceData.Core.Mapper
{
    public class RefDataProfile : Profile
    {
        public RefDataProfile()
        {
            CreateMap<State, StateModel>();
            CreateMap<Country, CountryModel>();
        }
    }
}
