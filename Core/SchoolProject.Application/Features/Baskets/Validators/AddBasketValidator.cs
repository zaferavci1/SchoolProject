using System;
using FluentValidation;
using SchoolProject.Application.Features.Baskets.Commands.Add;

namespace SchoolProject.Application.Features.Baskets.Valiators
{
    public class AddBasketValidator : AbstractValidator<AddBasketCommandRequest>
	{
		public AddBasketValidator()
		{
            RuleFor(basket => basket.BasketName)
                .NotEmpty().WithMessage("Sepet ismi boş olamaz.")
                .MaximumLength(50).WithMessage("Sepet ismi 50 karakterden az olmalıdır.");
        }
	}
}

