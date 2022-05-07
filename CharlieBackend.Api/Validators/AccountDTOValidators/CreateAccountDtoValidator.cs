﻿using CharlieBackend.Business.Helpers;
using CharlieBackend.Core.DTO.Account;
using FluentValidation;

namespace CharlieBackend.Api.Validators.AccountDTOValidators
{
    /// <summary>
    /// CreateAccountDtoValidator fluent validator
    /// </summary>
    public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
    {
        /// <summary>
        /// Fluent validation rules for CreateAccountDto
        /// </summary>
        public CreateAccountDtoValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .MaximumLength(ValidationConstants.MaxLengthName);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(ValidationConstants.MaxLengthName);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(ValidationConstants.MaxLengthEmail);
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(ValidationConstants.MinLength)
                .MaximumLength(ValidationConstants.MaxLengthPassword)
                .Must(PasswordHelper.PasswordValidation).WithMessage(ValidationConstants.PasswordRule);
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password).WithMessage(ValidationConstants.PasswordConfirmNotValid);
        }
    }
}
