using IdentityAndSecurity.Infrastructure.Entities;

namespace IdentityAndSecurity.Infrastructure.Repositories.Interfaces
{
    public interface IIdentityAndSecurityRepository
    {
        void Register(User user);
        User GetUserByUserName(string userName);
        UserLogin GetUserLoginByUserId(Guid? userId);
        void SaveUserLogin(UserLogin userLogin);

    }
}
