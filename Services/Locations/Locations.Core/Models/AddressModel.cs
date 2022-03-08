using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locations.Core.Models
{
    public class AddressModel
    {
        public Guid? Id { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryAbbreviation { get; set; }
        public string CountryName { get; set; }

    }
}
