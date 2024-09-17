using FluentValidation;
using FluentValidations_Sample.Dto;

namespace FluentValidations_Sample.Validators
{
    public class UserRegistratorValidator : AbstractValidator<UserRegistrationRequest>
    {
        public UserRegistratorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(IsValidName).WithMessage("{PropertyName} should contain only letters.").MinimumLength(4);

            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters long.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Email).EmailAddress().WithName("Email Id").WithMessage("{PropertyName} is invalid!.Please check.");
        }

        /// <summary>
        /// Custom validation to check if the name contains only letters
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
