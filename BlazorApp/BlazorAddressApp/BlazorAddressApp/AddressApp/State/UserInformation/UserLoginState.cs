using AddressApp.Models.UserInformation;
using AddressApp.Services;

namespace AddressApp.State.UserInformation
{
    public class UserLoginState
    {

        #region Constructor

        public UserLoginState(UserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Private Variables
        private UserService _userService { get; set; }

        #endregion

        #region Actions

        public Action OnUserLoginSuccessfully { get; set; }
        public Action OnCancelLogin { get; set; }
        public Action<List<string>> OnError { get; set; }

        #endregion

        #region Events
        public async Task Login(UserLoginModel model)
        {
            var results = await _userService.Login(model);
            if (results.ErrorMessages != null && results.ErrorMessages.Count() > 0)
                OnError?.Invoke(results.ErrorMessages);
            else
                OnUserLoginSuccessfully?.Invoke();
        }

        public void CancelLogin()
        {
            OnCancelLogin?.Invoke();

        }
        #endregion
    }
}
