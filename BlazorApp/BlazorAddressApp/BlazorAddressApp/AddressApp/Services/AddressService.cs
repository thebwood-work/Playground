using AddressApp.Models.Locations;

namespace AddressApp.Services
{
    public class AddressService : BaseService
    {
        #region Base URL
        
        private string _baseURL = "https://localhost:5010/";
        
        #endregion

        #region Address

        public async Task<List<AddressSearchResultsModel>> Search(AddressSearchModel search)
        {
            return await this.PostAPIResult<List<AddressSearchResultsModel>, AddressSearchModel>(_baseURL, "addresses/", search);
        }

        public async Task<AddressModel> Get(string addressId)
        {
            return await this.GetAPIResult<AddressModel>(_baseURL, string.Format(String.Format("addresses/{0}", addressId.ToString())));
        }


        public async Task<List<string>> Save(AddressModel address)
        {
            return await this.PostAPIResult<List<string>, AddressModel>(_baseURL, "addresses/", address);
        }

        public async Task<bool> Delete(string addressId)
        {
            return await this.DeleteAPIResult(_baseURL, string.Format(String.Format("addresses/{0}", addressId.ToString())));
        }
        #endregion

    }
}