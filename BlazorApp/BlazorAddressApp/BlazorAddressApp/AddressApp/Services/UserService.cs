using AddressApp.Models.UserInformation;


namespace AddressApp.Services
{
    public class UserService : BaseService
    {
        #region Users
        private string _baseURL = "https://localhost:5010/";

        public async Task<UserRegisterResponseModel> Register(UserRegistrationModel model)
        {
            return await this.PostAPIResult<UserRegisterResponseModel, UserRegistrationModel>(_baseURL, "register", model);
        }
        #endregion

    }
}
