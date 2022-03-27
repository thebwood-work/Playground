using AddressApp.Models.People;
using AddressApp.Services;
using Microsoft.AspNetCore.Components;


namespace AddressApp.State.People
{
    public class PersonDetailState
    {
        #region Constructor

        public PersonDetailState(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        #endregion

        #region Private Variables
        private PeopleService _peopleService {get;set;}

        #endregion

        #region Events

        public async Task Save(PersonModel model)
        {
            var results = await _peopleService.Save(model);
            if (results.Count() > 0)
                OnError?.Invoke(results);
            else
                OnPersonSavedSuccessfully?.Invoke();
        }

        public async Task Get(string id)
        {
            var result = await _peopleService.Get(id);
            HandleGetById?.Invoke(result);
        }

        #endregion

        #region Actions

        public Action OnPersonSavedSuccessfully { get; set; }
        public Action<PersonModel> HandleGetById { get; set; }
        public Action<List<string>> OnError { get; private set; }

        #endregion
    }
}
