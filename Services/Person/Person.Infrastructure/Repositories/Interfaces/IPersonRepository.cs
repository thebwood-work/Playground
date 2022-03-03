using Person.Infrastructure.Entities;

namespace Person.Infrastructure.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<People> Get();
        People Get(Guid? personId);
        void Save(People person);
        bool Delete(Guid? personId);

    }
}
