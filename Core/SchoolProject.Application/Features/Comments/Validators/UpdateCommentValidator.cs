using System;
using FluentValidation;
using SchoolProject.Application.Features.Comments.Commands.Update;

namespace SchoolProject.Application.Features.Comments.Validators
{
	public class UpdateCommentValidator :AbstractValidator<UpdateCommentCommandRequest>
	{
		public UpdateCommentValidator()
		{
            RuleFor(post => post.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(500).WithMessage("İçerik 500 karakterden az olmalıdır.");
        }
	}
}

