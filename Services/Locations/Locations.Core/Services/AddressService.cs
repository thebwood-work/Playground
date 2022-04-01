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

        public AddressModel Get(Guid? addressId)
        {
            var address = _repository.Get(addressId);
            var addressModel = new AddressModel();

            _mapper.Map(address, addressModel);

            return addressModel;
        }

        public List<string> Save(AddressModel address)
        {
            var errors = Validate(address);
            if (errors.Count() == 0)
            {
                var existingAddress = new Address();
                if (address.Id != null)
                    existingAddress = _repository.Get(address.Id);

                _mapper.Map<AddressModel, Address>(address, existingAddress);
                _repository.Save(existingAddress);
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

        public void SavePeopleAddresses(PersonAddressModel model)
        {
            foreach (var address in model.Addresses)
            {
                var existingAddress = new Address();
                var personAddress = new PeopleAddress();
                personAddress.PersonId = model.PersonId;

                if (address.Id != null)
                    existingAddress = _repository.Get(address.Id);

                _mapper.Map<AddressModel, Address>(address, existingAddress);
                existingAddress = _repository.Save(existingAddress);
                personAddress.AddressId = existingAddress.Id;
                
                _repository.SavePersonAddress(personAddress);
            }
            DeletePeopleAddresses(model);
        }

        private void DeletePeopleAddresses(PersonAddressModel model)
        {
            var existingPeopleAddresses = _repository.GetPeopleAddressesByPersonId(model.PersonId.Value);
            var deletePeopleAddresses = existingPeopleAddresses.Where(x => !model.Addresses.Any(y => x.Id == y.Id));

            foreach (var deletePersonAddress in deletePeopleAddresses)
            {
                _repository.DeletePersonAddress(deletePersonAddress.Id.Value);
            }
        }
    }
}
