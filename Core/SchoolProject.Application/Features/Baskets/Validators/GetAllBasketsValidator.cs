using System;
using FluentValidation;
using SchoolProject.Application.Features.Baskets.Queries.GetAll;

namespace SchoolProject.Application.Features.Baskets.Validators
{
	public class GetAllBasketsValidator : AbstractValidator<GetAllBasketsQueryRequest>
	{
		public GetAllBasketsValidator()
		{
            RuleFor(basket => basket.Page)
                .NotNull().WithMessage("Lütfen sayfa sayısını boş geçmeyiniz.");

            RuleFor(basket => basket.Size).NotEmpty()
                .GreaterThan(0).WithMessage("Lütfen büyüklügü 0'dan büyük giriniz.")
                .NotNull().WithMessage("Lütfen büyüklügü boş geçmeyiniz.");
        }
	}
}

