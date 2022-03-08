using Locations.Core.Models;

namespace Locations.Core.Services.Interfaces
{
    public interface IAddressService
    {
        List<string> Save(AddressModel person);
        IEnumerable<AddressModel> Get();
        AddressModel Get(Guid? personId);
        bool Delete(Guid? personId);

    }
}
