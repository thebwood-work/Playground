using People.Infrastructure.Entities;

namespace People.Infrastructure.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> Get();
        Person Get(Guid? personId);
        void Save(Person person);
        bool Delete(Guid? personId);

    }
}
