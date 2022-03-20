﻿using Microsoft.Extensions.Logging;
using People.Infrastructure.Entities;
using People.Infrastructure.Repositories.Interfaces;
using Playground.Infrastructure.Base.Repositories;

namespace People.Infrastructure.Repositories
{
    public class PeopleRepository : PlaygroundRepository<PeopleRepository>, IPeopleRepository
    {
        private PeopleContext _context;

        public PeopleRepository(ILogger<PeopleRepository> logger, PeopleContext context) : base(logger)
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

        public IEnumerable<Person> Get() => _context.People;

        public Person Get(Guid? personId) => _context.People.Where(x => x.Id == personId).SingleOrDefault();

        public void Save(Person person)
        {
            if (person.Id != null)
                _context.People.Update(person);
            else
                _context.People.Add(person);
            _context.SaveChanges();
        }

        public List<PersonSearchResults> Search(PersonSearch personSearch)
        {
            var results = (from p in _context.People
                           where (string.IsNullOrEmpty(personSearch.FirstName) || p.FirstName.Contains(personSearch.FirstName)) &&
                           (string.IsNullOrEmpty(personSearch.LastName) || p.LastName.Contains(personSearch.LastName))
                           select new PersonSearchResults
                           {
                               FirstName = p.FirstName,
                               LastName = p.LastName,
                               Id = p.Id.Value,
                               DateOfBirth = p.DateOfBirth
                           })
                    .OrderBy(a => a.LastName)
                    .OrderBy(a => a.FirstName)
                    .Take(1000)
                    .ToList();

            return results;
        }
    }
}
