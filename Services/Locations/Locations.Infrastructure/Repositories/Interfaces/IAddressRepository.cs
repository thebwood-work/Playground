using Locations.Infrastructure.Entities;

namespace Locations.Infrastructure.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> Get();
        Address Get(Guid? addressId);
        void Save(Address address);
        bool Delete(Guid? addressId);
        List<AddressSearchResults> Search(AddressSearch search);
    }
}
