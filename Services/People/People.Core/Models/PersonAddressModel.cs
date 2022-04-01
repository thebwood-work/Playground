namespace People.Core.Models
{
    public class PersonAddressModel
    {
        public Guid? Id { get; set; }
        public Guid? PersonId { get; set; }
        public Guid? AddressId { get; set; }

        public List<AddressModel> Addresses { get; set; }
    }
}
