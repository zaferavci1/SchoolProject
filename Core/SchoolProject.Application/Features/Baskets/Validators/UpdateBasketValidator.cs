using System;
using FluentValidation;
using SchoolProject.Application.Features.Baskets.Commands.Update;

namespace SchoolProject.Application.Features.Baskets.Validators
{
	public class UpdateBasketValidator : AbstractValidator<UpdateBasketCommandRequest>
	{
		public UpdateBasketValidator()
		{
            RuleFor(basket => basket.BasketName)
                .NotEmpty().WithMessage("Sepet ismi boş olamaz.")
                .MaximumLength(50).WithMessage("Sepet ismi 50 karakterden az olmalıdır.");
        }
	}
}

