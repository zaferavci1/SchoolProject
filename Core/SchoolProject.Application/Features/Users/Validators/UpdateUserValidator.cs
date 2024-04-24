using System;
using FluentValidation;
using SchoolProject.Application.Features.Users.Commands.Update;

namespace SchoolProject.Application.Features.Users.Validators
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserCommandRequest>
	{
		public UpdateUserValidator()
		{
            RuleFor(user => user.NickName).NotEmpty().WithMessage("Takma ad boş olamaz.");

            RuleFor(user => user.Name).NotEmpty().WithMessage("Ad boş olamaz.");

            RuleFor(user => user.Surname).NotEmpty().WithMessage("Soyad boş olamaz.");

            RuleFor(user => user.Mail)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }
	}
}

