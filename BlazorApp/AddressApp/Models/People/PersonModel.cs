﻿namespace AddressApp.Models.People
{
    public class PersonModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
