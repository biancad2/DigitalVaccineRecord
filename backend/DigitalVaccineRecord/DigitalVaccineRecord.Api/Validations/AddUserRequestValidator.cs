using DigitalVaccineRecord.Api.Commands.User;
using FluentValidation;

namespace DigitalVaccineRecord.Api.Validations
{
    public class AddUserCommandValidator
    : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(AddUserCommand settings)
        {
            RuleFor(command => command.FirstName)
                .NotEmpty()
                .WithMessage($"First name can't be empty.");

            RuleFor(command => command.Surname)
                .NotEmpty()
                .WithMessage($"Surname can't be empty.");

            RuleFor(command => command.Profiles)
                .NotEmpty()
                .WithMessage($"Select a profile");            
            
            RuleFor(command => command.NationalHealthCardNumber)
                .NotEmpty()
                .WithMessage($"Type your National Health Card number");


            RuleFor(command => command.BirthDate)
                .NotEmpty()
                .WithMessage($"Birth date can't be empty.");

            RuleFor(command => command.Document)
                .NotEmpty()
                .WithMessage($"Document can't be empty.");

            RuleFor(command => command.Gender)
                .NotEmpty()
                .WithMessage($"Select a gender.");
        }
    }
}
