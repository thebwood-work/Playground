using AddressApp.BaseClasses;
using Microsoft.AspNetCore.Components;
using AddressApp.Models.People;
using AddressApp.State.People;

namespace AddressApp.Pages.People.Components
{
    public partial class PeopleGrid : CommonPeopleFunctions
    {
        #region Parameters

        [Parameter]
        public PeopleSearchState PeopleSearchStateManagement { get; set; }

        #endregion

        #region Private Variables
        private List<PersonSearchResultsModel> _people;

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            PeopleSearchStateManagement.OnPeopleSearched += PeopleSearched;
            if (_people == null)
                _people = new List<PersonSearchResultsModel>();

        }
        protected void Dispose()
        {
            PeopleSearchStateManagement.OnPeopleSearched -= PeopleSearched;
        }
        #endregion
        #region Events

        private void EditPerson(Guid? personId)
        {
            this.NavigationManager.NavigateTo(String.Format("people/{0}", personId.ToString()));
        }

        private void PeopleSearched(List<PersonSearchResultsModel> people)
        {
            _people = people;
            StateHasChanged();
        }
        #endregion
    }
}
