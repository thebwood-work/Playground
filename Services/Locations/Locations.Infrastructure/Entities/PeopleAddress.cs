using System;
using System.Collections.Generic;

namespace Locations.Infrastructure.Entities
{
    public partial class PeopleAddress
    {
        public Guid? Id { get; set; }
        public Guid? PersonId { get; set; }
        public Guid? AddressId { get; set; }
    }
}
