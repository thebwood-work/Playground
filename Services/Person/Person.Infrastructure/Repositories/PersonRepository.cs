using Microsoft.Extensions.Logging;
using Person.Infrastructure.Entities;
using Person.Infrastructure.Repositories.Interfaces;
using Playground.Web.Base.Repositories;

namespace Person.Infrastructure.Repositories
{
    public class PersonRepository : PlaygroundRepository<PersonRepository>, IPersonRepository
    {
        private PersonContext _context;

        protected PersonRepository(ILogger<PersonRepository> logger, PersonContext context) : base(logger)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public bool Delete(Guid? personId)
        {
            try
            {
                var person = Get(personId);
                _context.People.Remove(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("", ex);
                return false;
            }
            return true;
        }

        public IEnumerable<People> Get() => _context.People;

        public People Get(Guid? personId) => _context.People.Where(x => x.Id == personId).SingleOrDefault();

        public void Save(People person)
        {
            if (person.Id != null)
                _context.People.Update(person);
            else
                _context.People.Add(person);
            _context.SaveChanges();
        }
    }
}
