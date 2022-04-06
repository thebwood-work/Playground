using AddressApp.Models.UserInformation;
using AddressApp.Services;

namespace AddressApp.State.UserInformation
{
    public class UserRegistrationState
    {
        #region Constructor

        public UserRegistrationState(UserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Private Variables
        private UserService _userService { get; set; }

        #endregion

        #region Events

        public async Task Register(UserRegistrationModel model)
        {
            var results = await _userService.Register(model);
            if (results.ErrorMessages != null && results.ErrorMessages.Count() > 0)
                OnError?.Invoke(results.ErrorMessages);
            else
                OnUserSavedSuccessfully?.Invoke();
        }
        public void CancelSave()
        {
            OnCancelSave?.Invoke();
        }

        #endregion

        #region Actions

        public Action OnUserSavedSuccessfully { get; set; }
        public Action OnCancelSave { get; set; }
        public Action<List<string>> OnError { get; set; }

        #endregion

    }
}
