using System;
using FluentValidation.Entities;
using FluentValidation.Validators;

namespace FluentValidationCreate
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(){
                Id = 123,
                FirstName = "Luiz",
                IdTypePerson = 2,
                DateBorn = new DateTime(2019, 1, 21)
            };

            PersonValidator validator = new PersonValidator();

            var result = validator.Validate(person);

            Console.WriteLine(String.Join("\n", result.Errors));
        }
    }
}
