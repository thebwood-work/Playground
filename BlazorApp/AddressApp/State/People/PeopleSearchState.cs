using AddressApp.BaseClasses;
using AddressApp.Models.People;
using AddressApp.Services;

namespace AddressApp.State.People
{
    public class PeopleSearchState
    {
        #region Constructor

        public PeopleSearchState(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        #endregion

        #region Private Variables
        private PeopleService _peopleService { get; set; }

        #endregion

        #region Events

        public async Task Search(PersonSearchModel searchModel)
        {
            var results = await _peopleService.Search(searchModel);
            OnPeopleSearched?.Invoke(results);
        }

        #endregion

        #region Actions
        public Action<List<PersonSearchResultsModel>> OnPeopleSearched { get; set; }
        #endregion

    }
}
