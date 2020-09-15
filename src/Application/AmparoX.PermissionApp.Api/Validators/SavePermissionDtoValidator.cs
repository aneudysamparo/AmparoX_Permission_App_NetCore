using AmparoX.PermissionApp.Api.Dtos;
using FluentValidation;
using System;

namespace AmparoX.PermissionApp.Api.Validators
{
    public class SavePermissionDtoValidator: AbstractValidator<SavePermissionDto>
    {
        public SavePermissionDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
