using Locations.Infrastructure.Entities;

namespace Locations.Infrastructure.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> Get();
        Address Get(Guid? addressId);
        Address Save(Address address);
        bool Delete(Guid? addressId);
        List<AddressSearchResults> Search(AddressSearch search);

        IEnumerable<PeopleAddress> GetPeopleAddressesByPersonId(Guid personId);
        void SavePersonAddress(PeopleAddress address);
        public bool DeletePersonAddress(Guid id);
    }
}
