namespace AddressApp.Models.Locations
{
    public class AddressSearchModel
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string ZipCode { get; set; }

    }
}
