using AutoMapper;
using Locations.Core.Models;
using Locations.Infrastructure.Entities;

namespace Locations.Core.Mapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();
        }
    }
}
