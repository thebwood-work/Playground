using AddressApp.BaseClasses;
using AddressApp.Models.Locations;
using AddressApp.Services;
using AddressApp.State.Addresses;
using Microsoft.AspNetCore.Components;

namespace AddressApp.Pages.Addresses
{
    public partial class Addresses : CommonLocationFunctions
    {
        #region Private Variables
        private AddressSearchState _addressSearchStateManagement;

        [Inject]
        private AddressService _AddressService { get; set; }
        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _addressSearchStateManagement = new AddressSearchState(_AddressService);
            await Search(new AddressSearchModel());
        }
        #endregion

        #region Events

        private void AddAddress()
        {
            this.NavigationManager.NavigateTo("addresses/Add");

        }

        private async Task Search(AddressSearchModel searchModel)
        {
            await _addressSearchStateManagement.Search(searchModel);
        }


        #endregion

    }
}
