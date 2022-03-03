using AutoMapper;
using Microsoft.Extensions.Logging;
using Person.Core.Models;
using Person.Core.Services.Interfaces;
using Person.Infrastructure.Entities;
using Person.Infrastructure.Repositories.Interfaces;
using Playground.Web.Base.Services;

namespace Person.Core.Services
{
    public class PersonService : PlaygroundService<PersonService>, IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(ILogger<PersonService> logger, IPersonRepository respository, IMapper mapper) : base(logger)
        {
            _repository = respository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public bool Delete(Guid? personId)
        {
            try
            {
                _repository.Delete(personId);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Delete", ex);
                return false;
            }

            return true;
        }

        public IEnumerable<PersonModel> Get()
        {
            IEnumerable<PersonModel> results = new List<PersonModel>();
            try
            {
                var values = _repository.Get();
                _mapper.Map(values, results);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Get", ex);
            }
            return results;
        }

        public PersonModel Get(Guid? personId)
        {
            var game = _repository.Get(personId);
            var gameModel = new PersonModel();

            _mapper.Map(game, gameModel);

            return gameModel;
        }

        public List<string> Save(PersonModel person)
        {
            var errors = Validate(person);
            if (errors.Count() == 0)
            {
                var existingPerson = new People();
                if (person.Id != null)
                    existingPerson = _repository.Get(person.Id);

                _mapper.Map<PersonModel, People>(person, existingPerson);
                _repository.Save(existingPerson);
            }

            return errors;
        }

        private List<string> Validate(PersonModel person)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(person.FirstName))
            {
                errors.Add("Title is required");
            }
            if (String.IsNullOrWhiteSpace(person.LastName))
            {
                errors.Add("Description is required");
            }
            return errors;
        }
    }
}
