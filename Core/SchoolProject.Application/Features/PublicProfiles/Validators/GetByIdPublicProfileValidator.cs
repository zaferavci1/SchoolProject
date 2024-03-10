using System;
using FluentValidation;
using SchoolProject.Application.Features.PublicProfiles.Queries.GetById;

namespace SchoolProject.Application.Features.PublicProfiles.Validators
{
	public class GetByIdPublicProfileValidator:AbstractValidator<GetByIdPublicProfileRequest>
	{
		public GetByIdPublicProfileValidator()
		{
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kategori id'sini boş geçmeyiniz.")
                    .WithMessage("Lütfen kategori id'sini 0'dan büyük giriniz.");
        }
    }
}

