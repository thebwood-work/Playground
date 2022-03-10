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
        [Required(ErrorMessage = "Birth City is Required")]
        public string BirthCity { get; set; }
        [Required(ErrorMessage = "Birth State is Required")]
        public int? BirthStateId { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public int? StateId { get; set; }

    }
}
