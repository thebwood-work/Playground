using AddressApp.Models.People;

namespace AddressApp.Services
{
    public class PeopleService : BaseService
    {
        #region People

        public async Task<List<PersonModel>> Get()
        {
            var baseURL = "https://localhost:44308/";
            return await this.GetAPIResult<List<PersonModel>>(baseURL, "api/people/");
        }

        public async Task<PersonModel> Get(long personId)
        {
            var baseURL = "https://localhost:44308/";
            return await this.GetAPIResult<PersonModel>(baseURL, "api/people/" + personId.ToString());
        }


        public async Task<List<string>> Save(PersonModel person)
        {
            var baseURL = "https://localhost:44308/";
            return await this.PostAPIResult<List<string>, PersonModel>(baseURL, "api/people/", person);
        }

        #endregion

    }
}
