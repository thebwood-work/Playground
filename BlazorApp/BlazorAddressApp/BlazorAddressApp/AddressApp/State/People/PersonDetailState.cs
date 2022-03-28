using AddressApp.Models.People;
using AddressApp.Services;


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
        private PeopleService _peopleService { get; set; }

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
        public void CancelSave()
        {
            OnCancelSave?.Invoke();
        }

        public async Task Get(Guid id)
        {
            var result = await _peopleService.Get(id);
            OnPersonLoaded?.Invoke(result);
        }

        #endregion

        #region Actions

        public Action OnPersonSavedSuccessfully { get; set; }
        public Action OnCancelSave { get; set; }
        public Action<PersonModel> OnPersonLoaded { get; set; }
        public Action<List<string>> OnError { get; private set; }

        #endregion
    }
}
