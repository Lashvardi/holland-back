using doit.Models.DTOs;
using FluentValidation;

namespace doit.Validations
{
    public class MessageValidation : AbstractValidator<MessageDTO>
    {
        public MessageValidation()
        {
            // Validate FullName
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Length(2, 100).WithMessage("Full Name must be between 2 and 100 characters.");

            // Validate Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            // Validate PhoneNumber
            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Phone number is not valid.");


        }
    }
}