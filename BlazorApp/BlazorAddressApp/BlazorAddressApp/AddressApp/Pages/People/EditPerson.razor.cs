using AddressApp.BaseClasses;
using AddressApp.Models.People;
using AddressApp.Services;
using AddressApp.State.People;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AddressApp.Pages.People
{
    public partial class EditPerson : CommonPeopleFunctions, IDisposable
    {
        #region Parameters
        [Parameter]
        public Guid PersonId { get; set; }
        #endregion

        #region Private Variables

        [Inject]
        private PeopleService _peopleService { get; set; }

        private EditContext _editContext;
        private PersonDetailState _personDetailStateManagement;

        private PersonModel _person = new PersonModel();

        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _personDetailStateManagement = new PersonDetailState(_peopleService);
            _personDetailStateManagement.OnPersonSavedSuccessfully += OnSaved;
            _personDetailStateManagement.OnPersonLoaded += PersonLoaded;
            _personDetailStateManagement.OnCancelSave += OnCancelSave;

            await LoadPerson(PersonId);
        }

        protected override void OnParametersSet()
        {
            _editContext = new EditContext(_person);
        }

        public void Dispose()
        {
            _personDetailStateManagement.OnPersonSavedSuccessfully -= OnSaved;
            _personDetailStateManagement.OnPersonLoaded -= PersonLoaded;
            _personDetailStateManagement.OnCancelSave -= OnCancelSave;
        }

        #endregion

        #region Events


        private async Task LoadPerson(Guid personId)
        {
            await _personDetailStateManagement.Get(personId);
        }

        private async Task SavePerson()
        {
            if (_editContext.Validate())
            {
                await _personDetailStateManagement.Save(_person);
            }
        }

        private void CancelSave()
        {
            _personDetailStateManagement.CancelSave();
        }

        private void OnSaved()
        {
            NavigationManager.NavigateTo("people");
        }

        private void OnCancelSave()
        {
            NavigationManager.NavigateTo("people");
        }

        private void PersonLoaded(PersonModel person)
        {
            _person = person;
            _editContext = new EditContext(_person);
            this.StateHasChanged();
        }

        #endregion

    }
}
