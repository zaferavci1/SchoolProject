using System;
using FluentValidation;
using SchoolProject.Application.Features.Users.Queries.GetAll;

namespace SchoolProject.Application.Features.Users.Validators
{
	public class GetAllUsersValidator : AbstractValidator<GetAllUserQueryRequest>
	{
		public GetAllUsersValidator()
		{

			RuleFor(user => user.Page)
                .NotNull().WithMessage("Lütfen sayfa sayısını boş geçmeyiniz.");

            RuleFor(user => user.Size).NotEmpty()
				.GreaterThan(0).WithMessage("Lütfen büyüklügü 0'dan büyük giriniz.")
                .NotNull().WithMessage("Lütfen büyüklügü boş geçmeyiniz.");
        }
	}
}

