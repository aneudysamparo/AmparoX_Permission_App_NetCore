using AmparoX.PermissionApp.Api.Dtos;
using FluentValidation;

namespace AmparoX.PermissionApp.Api.Validators
{
    public class SavePermissionTypeDtoValidator : AbstractValidator<SavePermissionTypeDto>
    {
        public SavePermissionTypeDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100);
        }
    
    }
}
