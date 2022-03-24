using AutoMapper;
using Locations.Core.Models;
using Locations.Core.Services.Interfaces;
using Locations.Infrastructure.Entities;
using Locations.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Playground.Core.Base.Services;

namespace Locations.Core.Services
{
    public class AddressService : PlaygroundService<AddressService>, IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;


        public AddressService(ILogger<AddressService> logger, IAddressRepository respository, IMapper mapper) : base(logger)
        {
            _repository = respository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();

        }

        public List<AddressSearchResultsModel> Search(AddressSearchModel model)
        {
            var search = new AddressSearch();
            _mapper.Map(model, search);

            var searchResults = _repository.Search(search);
            var searchResultsModel = new List<AddressSearchResultsModel>();

            _mapper.Map(searchResults, searchResultsModel);

            return searchResultsModel;

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

        public IEnumerable<AddressModel> Get()
        {
            IEnumerable<AddressModel> results = new List<AddressModel>();
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

        public AddressModel Get(Guid? personId)
        {
            var game = _repository.Get(personId);
            var gameModel = new AddressModel();

            _mapper.Map(game, gameModel);

            return gameModel;
        }

        public List<string> Save(AddressModel person)
        {
            var errors = Validate(person);
            if (errors.Count() == 0)
            {
                var existingPerson = new Address();
                if (person.Id != null)
                    existingPerson = _repository.Get(person.Id);

                _mapper.Map<AddressModel, Address>(person, existingPerson);
                _repository.Save(existingPerson);
            }

            return errors;
        }

        private List<string> Validate(AddressModel person)
        {
            var errors = new List<string>();
            if(String.IsNullOrEmpty(person.StreetName))
            {
                errors.Add("Street Name is required");
            }

            if (String.IsNullOrWhiteSpace(person.City))
            {
                errors.Add("City is required");
            }
            return errors;
        }
    }
}
