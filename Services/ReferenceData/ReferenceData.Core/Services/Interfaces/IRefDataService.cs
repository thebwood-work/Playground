using ReferenceData.Core.Models;

namespace ReferenceData.Core.Services.Interfaces
{
    public interface IRefDataService
    {
        IEnumerable<StateModel> GetStates();
        IEnumerable<CountryModel> GetCountries();

    }
}
