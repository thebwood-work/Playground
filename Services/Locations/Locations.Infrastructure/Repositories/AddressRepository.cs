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

        public IEnumerable<Address> Get() => _context.Addresses;

        public Address Get(Guid? addressId) => _context.Addresses.Where(x => x.Id == addressId).SingleOrDefault();

        public void Save(Address address)
        {
            if (address.Id != null)
                _context.Addresses.Update(address);
            else
                _context.Addresses.Add(address);
            _context.SaveChanges();
        }
    }
}
