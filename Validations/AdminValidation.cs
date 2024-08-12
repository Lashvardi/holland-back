using doit.Models;
using doit.Models.DTOs;
using FluentValidation;

namespace doit.Validations;

public class AdminValidation : AbstractValidator<AdminDto>
{
    public AdminValidation()
    {
        RuleFor(a => a.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        
        // Password Example: Abc@1234
        RuleFor(a => a.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        

    }
    
}