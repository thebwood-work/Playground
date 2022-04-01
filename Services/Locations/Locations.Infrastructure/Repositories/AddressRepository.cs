using Locations.Infrastructure.Entities;
using Locations.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Playground.Infrastructure.Base.Repositories;

namespace Locations.Infrastructure.Repositories
{
    public class AddressRepository : PlaygroundRepository<AddressRepository>, IAddressRepository
    {
        private LocationsContext _context;

        public AddressRepository(ILogger<AddressRepository> logger, LocationsContext context) : base(logger)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public bool Delete(Guid? addressId)
        {
            try
            {
                var address = Get(addressId);
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("", ex);
                return false;
            }
            return true;
        }
        public List<AddressSearchResults> Search(AddressSearch search)
        {
            var results = (from p in _context.Addresses
                           where (string.IsNullOrWhiteSpace(search.StreetNumber) || p.StreetNumber.Contains(search.StreetNumber)) &&
                           (string.IsNullOrWhiteSpace(search.StreetName) || p.StreetName.Contains(search.StreetName)) &&
                           (string.IsNullOrWhiteSpace(search.City) || p.City.Contains(search.City)) &&
                           (search.StateId == null || p.StateId == search.StateId) &&
                           (string.IsNullOrWhiteSpace(search.ZipCode) || p.ZipCode.Contains(search.ZipCode))
                           select new AddressSearchResults
                           {
                               Id = p.Id.Value,
                               StreetNumber = p.StreetNumber,
                               StreetName = p.StreetName,
                               City = p.City,
                               StateName = p.StateName,
                               ZipCode = p.ZipCode,
                           })
                            .OrderBy(a => a.StateName)
                            .OrderBy(a => a.City)
                            .Take(1000)
                            .ToList();

            return results;

        }

        public IEnumerable<Address> Get() => _context.Addresses;

        public Address Get(Guid? addressId) => _context.Addresses.Where(x => x.Id == addressId).SingleOrDefault();

        public Address Save(Address address)
        {
            if (address.Id != null)
                _context.Addresses.Update(address);
            else
                _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;

        }

        public PeopleAddress GetPeopleAddressByID(Guid id) => _context.PeopleAddresses.Where(x => x.Id == id).SingleOrDefault();

        public IEnumerable<PeopleAddress> GetPeopleAddressesByPersonId(Guid personId) => _context.PeopleAddresses.Where(x => x.PersonId == personId);

        public void SavePersonAddress(PeopleAddress address)
        {
            if (address.Id != null)
                _context.PeopleAddresses.Update(address);
            else
                _context.PeopleAddresses.Add(address);
            _context.SaveChanges();
        }

        public bool DeletePersonAddress(Guid id)
        {
            try
            {
                var personAddress = GetPeopleAddressByID(id);
                _context.PeopleAddresses.Remove(personAddress);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("", ex);
                return false;
            }
            return true;
        }
    }
}
