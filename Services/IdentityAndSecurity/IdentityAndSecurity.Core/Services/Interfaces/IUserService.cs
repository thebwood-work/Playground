using IdentityAndSecurity.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAndSecurity.Core.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
    }
}
