using AddressApp.BaseClasses;
using AddressApp.Models.UserInformation;
using AddressApp.Services;
using AddressApp.State.UserInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AddressApp.Pages.UserInformation
{
    public partial class Login : CommonUserFunctions, IDisposable
    {

        #region Private Variables

        [Inject]
        private UserService _userService { get; set; }

        private EditContext _editContext;
        private UserLoginState _userLoginStateManagement;

        private UserLoginModel _user = new UserLoginModel();
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
        private InputType _passwordInput = InputType.Password;
        private bool _isShow = false;
        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _userLoginStateManagement = new UserLoginState(_userService);
            _userLoginStateManagement.OnUserLoginSuccessfully += OnSaved;
            _userLoginStateManagement.OnCancelLogin += OnCancelSave;
            _userLoginStateManagement.OnError += OnError;
        }

        protected override void OnParametersSet()
        {
            _editContext = new EditContext(_user);
        }

        public void Dispose()
        {
            _userLoginStateManagement.OnUserLoginSuccessfully -= OnSaved;
            _userLoginStateManagement.OnCancelLogin -= OnCancelSave;
            _userLoginStateManagement.OnError -= OnError;
        }

        #endregion

        #region Events

        void ToggleShowPassword()
        {
            if (_isShow)
            {
                _isShow = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _isShow = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }
        private async Task LoginUser()
        {
            if (_editContext.Validate())
            {
                await _userLoginStateManagement.Login(_user);
            }
        }

        private void CancelLogin()
        {
            _userLoginStateManagement.CancelLogin();
        }

        private void OnSaved()
        {
            this.ShowSnackbarSuccess("Login successfully");
            NavigationManager.NavigateTo("dashboard");
        }
        private void OnError(List<string> errors)
        {
            this.ShowSnackbarError(errors);
        }

        private void OnCancelSave()
        {
            NavigationManager.NavigateTo("dashboard");
        }

        #endregion

    }
}
