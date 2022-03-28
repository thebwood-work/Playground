using AddressApp.BaseClasses;
using AddressApp.Models.People;
using AddressApp.Services;
using AddressApp.State.People;
using Microsoft.AspNetCore.Components;

namespace AddressApp.Pages.People
{
    public partial class People : CommonPeopleFunctions
    {
        #region Private Variables
        private PeopleSearchState _peopleSearchStateManagement;

        [Inject]
        private PeopleService _peopleService { get; set; }
        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _peopleSearchStateManagement = new PeopleSearchState(_peopleService);
            await Search(new PersonSearchModel());
        }
        #endregion

        #region Events

        private void AddGame()
        {
            this.NavigationManager.NavigateTo("games/Add");

        }

        private async Task Search(PersonSearchModel searchModel)
        {
            await _peopleSearchStateManagement.Search(searchModel);
        }


        #endregion
    }
}
