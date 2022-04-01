using People.Core.Models;

namespace People.Core.Services.Interfaces
{
    public interface IPeopleService
    {
        Task<List<string>> Save(PersonModel person);
        IEnumerable<PersonModel> Get();
        PersonModel Get(Guid? personId);
        bool Delete(Guid? personId);
        List<PersonSearchResultsModel> Search(PersonSearchModel searchRequest);
    }
}
