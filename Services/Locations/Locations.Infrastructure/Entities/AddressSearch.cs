using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locations.Infrastructure.Entities
{
    public class AddressSearch
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string ZipCode { get; set; }

    }
}
