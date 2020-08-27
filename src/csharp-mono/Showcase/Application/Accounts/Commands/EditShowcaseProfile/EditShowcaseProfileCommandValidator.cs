using FluentValidation;

namespace Showcase.Application.Accounts.Commands.EditShowcaseProfile
{
    public class EditShowcaseProfileCommandValidator : AbstractValidator<EditShowcaseProfileCommand>
    {
        public EditShowcaseProfileCommandValidator()
        {
            RuleFor(x => x.NewProfileName).MaximumLength(100);
            RuleFor(x => x.NewProfileUsername).MaximumLength(50);
        }
    }
}
