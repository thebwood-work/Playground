using AddressApp.Models.Locations;
using AddressApp.State.Addresses;
using Microsoft.AspNetCore.Components;

namespace AddressApp.Pages.Addresses.Components
{
    public partial class AddressGrid
    {
        #region Parameters

        [Parameter]
        public AddressSearchState AddressSearchStateManagement { get; set; }

        #endregion

        #region Private Variables
        private List<AddressSearchResultsModel> _addresses;

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            AddressSearchStateManagement.OnAddressSearched += AddressSearched;
            if (_addresses == null)
                _addresses = new List<AddressSearchResultsModel>();

        }
        protected void Dispose()
        {
            AddressSearchStateManagement.OnAddressSearched -= AddressSearched;
        }
        #endregion
        #region Events

        private void EditAddress(Guid? addressId)
        {
            this.NavigationManager.NavigateTo(String.Format("addresses/{0}", addressId.ToString()));
        }

        private void AddressSearched(List<AddressSearchResultsModel> addresses)
        {
            _addresses = addresses;
            StateHasChanged();
        }
        #endregion
    }
}
