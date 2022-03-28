using AddressApp.BaseClasses;
using AddressApp.Models.Locations;
using AddressApp.State.Addresses;
using Microsoft.AspNetCore.Components;

namespace AddressApp.Pages.Addresses.Components
{
    public partial class AddressSearchForm : CommonLocationFunctions
    {
        #region Private Variables
        private AddressSearchModel _searchModel = new AddressSearchModel();
        #endregion

        #region Parameters

        [Parameter]
        public AddressSearchState AddressSearchStateManagement { get; set; }

        #endregion

        #region Events

        private async Task Search()
        {
            await AddressSearchStateManagement.Search(_searchModel);
        }
        private void Reset()
        {
            _searchModel = new AddressSearchModel();
        }

        #endregion

    }
}
