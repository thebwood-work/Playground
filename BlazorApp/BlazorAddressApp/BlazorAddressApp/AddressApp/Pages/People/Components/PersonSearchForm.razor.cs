using AddressApp.BaseClasses;
using AddressApp.Models.People;
using AddressApp.State.People;
using Microsoft.AspNetCore.Components;

namespace AddressApp.Pages.People.Components
{
    public partial class PersonSearchForm : CommonPeopleFunctions
    {
        #region Private Variables
        private PersonSearchModel _searchModel = new PersonSearchModel();
        #endregion

        #region Parameters

        [Parameter]
        public PeopleSearchState PeopleSearchStateManagement { get; set; }

        #endregion

        #region Events

        private async Task Search()
        {
            await PeopleSearchStateManagement.Search(_searchModel);
        }
        private void Reset()
        {
            _searchModel = new PersonSearchModel();
        }

        #endregion
    }
}
