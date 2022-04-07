using System.ComponentModel.DataAnnotations;

namespace AddressApp.Models.UserInformation
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
