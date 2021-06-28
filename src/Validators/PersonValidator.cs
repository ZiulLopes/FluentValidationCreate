using System;
using FluentValidation.Entities;

namespace FluentValidation.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Id)
                .NotNull().WithMessage("Código não pode ser nulo!");
            
            RuleFor(person => person.LastName)
                .NotNull().WithMessage("Sobre nome não pode ser vazio ou nulo");

            RuleFor(person => person.DateBorn)
                .NotNull().GreaterThanOrEqualTo(new DateTime(1990, 1, 1))
                .WithMessage("Data de nascimento não pode ser vazia ou nula e deve ser superior ao 01/01/1990");

            // RuleFor(person => person)
            //     .NotNull().Must(p => {
            //         return (DateTime.Now.Year - p.DateBorn.Year > 10);
            //     })
            //     .WithMessage("Pessoa Jurídica deve ter mais de 10 anos!")
            //     .When(person => person.IdTypePerson == 2);

            When(person => person.IdTypePerson == 2, () => {
                RuleFor(person => person)
                    .NotNull().Must(p => {
                        return (DateTime.Now.Year - p.DateBorn.Year > 10);
                    })
                .WithMessage("Pessoa Jurídica deve ter mais de 10 anos!");
            });
        }
    }
}