using System;

namespace FluentValidation.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdTypePerson { get; set; }
        public DateTime DateBorn { get; set; }
    }
}