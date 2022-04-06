using System.ComponentModel.DataAnnotations;

namespace AddressApp.Models.UserInformation
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "E-Mail Address is required")]
        public string Email { get; set; }

    }
}
