using System;
using FluentValidation;
using SchoolProject.Application.Features.Users.Commands.Add;

namespace SchoolProject.Application.Features.Users.Validators
{
	public class AddUserValidator : AbstractValidator<AddUserCommandRequest>
	{
		public AddUserValidator()
		{
            RuleFor(user => user.NickName).NotEmpty().WithMessage("Takma ad boş olamaz.");
             
            RuleFor(user => user.Name).NotEmpty().WithMessage("Ad boş olamaz.");
             
            RuleFor(user => user.Surname).NotEmpty().WithMessage("Soyad boş olamaz.");
             
            RuleFor(user => user.Mail)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
             
            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+\d{1,3}\s\d{1,3}\s\d{4,10}$").WithMessage("Telefon numarası geçersiz. Format: +Kod Alan Kodu Numara");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");

        }
    }
}

