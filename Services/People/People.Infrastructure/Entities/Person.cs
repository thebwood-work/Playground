using System;
using System.Collections.Generic;

namespace People.Infrastructure.Entities
{
    public partial class Person
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
