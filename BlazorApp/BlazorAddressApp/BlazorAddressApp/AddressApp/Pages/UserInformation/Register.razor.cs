using AddressApp.BaseClasses;
using AddressApp.Models.UserInformation;
using AddressApp.Services;
using AddressApp.State.UserInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AddressApp.Pages.UserInformation
{
    public partial class Register : CommonUserFunctions, IDisposable
    {

        #region Private Variables

        [Inject]
        private UserService _userService { get; set; }

        private EditContext _editContext;
        private UserRegistrationState _userRegistrationStateManagement;

        private UserRegistrationModel _user = new UserRegistrationModel();
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
        private InputType _passwordInput= InputType.Password;
        private bool _isShow = false;
        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _userRegistrationStateManagement = new UserRegistrationState(_userService);
            _userRegistrationStateManagement.OnUserSavedSuccessfully += OnSaved;
            _userRegistrationStateManagement.OnCancelSave += OnCancelSave;
            _userRegistrationStateManagement.OnError += OnError;
        }

        protected override void OnParametersSet()
        {
            _editContext = new EditContext(_user);
        }

        public void Dispose()
        {
            _userRegistrationStateManagement.OnUserSavedSuccessfully -= OnSaved;
            _userRegistrationStateManagement.OnCancelSave -= OnCancelSave;
            _userRegistrationStateManagement.OnError -= OnError;
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
        private async Task RegisterUser()
        {
            if (_editContext.Validate())
            {
                await _userRegistrationStateManagement.Register(_user);
            }
        }

        private void CancelSave()
        {
            _userRegistrationStateManagement.CancelSave();
        }

        private void OnSaved()
        {
            this.ShowSnackbarSuccess("Your account was created successfully");
            NavigationManager.NavigateTo("/");
        }
        private void OnError(List<string> errors)
        {
            this.ShowSnackbarError(errors);
        }

        private void OnCancelSave()
        {
            NavigationManager.NavigateTo("/");
        }

        #endregion

    }
}
