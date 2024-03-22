using System;
using FluentValidation;
using SchoolProject.Application.Features.Comments.Queries.GetAll;

namespace SchoolProject.Application.Features.Comments.Validators
{
	public class GetAllCommentsValidator : AbstractValidator<GetAllCommentQueryRequest>
	{
		public GetAllCommentsValidator()
		{
            RuleFor(comment => comment.Page)
                .NotNull().WithMessage("Lütfen sayfa sayısını boş geçmeyiniz.");    

            RuleFor(comment => comment.Size).NotEmpty()
                .GreaterThan(0).WithMessage("Lütfen büyüklügü 0'dan büyük giriniz.")
                .NotNull().WithMessage("Lütfen büyüklügü boş geçmeyiniz.");
        }
	}
}

