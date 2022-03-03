using System;
using System.Collections.Generic;

namespace Person.Infrastructure.Entities
{
    public partial class People
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
    }
}
