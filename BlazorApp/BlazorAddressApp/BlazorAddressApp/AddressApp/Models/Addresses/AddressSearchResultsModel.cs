namespace AddressApp.Models.Locations
{
    public class AddressSearchResultsModel
    {
        public Guid? Id { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }

    }
}
