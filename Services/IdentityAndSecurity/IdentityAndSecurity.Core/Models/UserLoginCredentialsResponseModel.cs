using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAndSecurity.Core.Models
{
    public class UserLoginCredentialsResponseModel
    {
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
