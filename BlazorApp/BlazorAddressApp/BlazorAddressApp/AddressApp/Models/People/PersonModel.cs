using System.ComponentModel.DataAnnotations;

namespace AddressApp.Models.People
{
    public class PersonModel
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
