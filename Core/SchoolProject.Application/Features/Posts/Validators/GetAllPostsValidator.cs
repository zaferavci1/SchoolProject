using System;
using FluentValidation;
using SchoolProject.Application.Features.Posts.Queries.GetAll;

namespace SchoolProject.Application.Features.Posts.Validators.Add
{
	public class GetAllPostsValidator :AbstractValidator<GetAllPostQueryRequest>
	{
		public GetAllPostsValidator()
		{

            RuleFor(post => post.Page)
                .NotNull().WithMessage("Lütfen sayfa sayısını boş geçmeyiniz.");

            RuleFor(post => post.Size).NotEmpty()
                .GreaterThan(0).WithMessage("Lütfen büyüklügü 0'dan büyük giriniz.")
                .NotNull().WithMessage("Lütfen büyüklügü boş geçmeyiniz.");
        }
	}
}

