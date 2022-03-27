using AddressApp.Models.People;

namespace AddressApp.Services
{
    public class PeopleService : BaseService
    {
        #region People
        private string _baseURL = "https://localhost:5010/";

        public async Task<List<PersonSearchResultsModel>> Search(PersonSearchModel searchModel)
        {
            return await this.PostAPIResult<List<PersonSearchResultsModel>, PersonSearchModel>(_baseURL, "people/search", searchModel);
        }

        public async Task<PersonModel> Get(string personId)
        {
            return await this.GetAPIResult<PersonModel>(_baseURL, string.Format(String.Format("people/{0}", personId.ToString())));
        }


        public async Task<List<string>> Save(PersonModel personModel)
        {
            return await this.PostAPIResult<List<string>, PersonModel>(_baseURL, "people/", personModel);
        }

        public async Task<bool> Delete(string personId)
        {
            return await this.DeleteAPIResult(_baseURL, string.Format(String.Format("people/{0}", personId.ToString())));
        }
        #endregion

    }
}
