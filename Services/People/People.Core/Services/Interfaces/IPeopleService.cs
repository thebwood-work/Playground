using People.Core.Models;

namespace People.Core.Services.Interfaces
{
    public interface IPeopleService
    {
        List<string> Save(PersonModel person);
        IEnumerable<PersonModel> Get();
        PersonModel Get(Guid? personId);
        bool Delete(Guid? personId);

    }
}
