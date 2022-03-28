using AddressApp.Models.Locations;
using AddressApp.Services;

namespace AddressApp.State.Addresses
{
    public class AddressSearchState
    {
        #region Constructor

        public AddressSearchState(AddressService locationService)
        {
            _locationService = locationService;
        }


        #endregion

        #region Private Variables
        private AddressService _locationService { get; set; }

        #endregion

        #region Events

        public async Task Search(AddressSearchModel searchModel)
        {
            var results = await _locationService.Search(searchModel);
            OnPeopleSearched?.Invoke(results);
        }

        #endregion

        #region Actions
        public Action<List<AddressSearchResultsModel>> OnPeopleSearched { get; set; }
        #endregion


    }
}