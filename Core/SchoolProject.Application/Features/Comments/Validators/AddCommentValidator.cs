using System;
using FluentValidation;
using SchoolProject.Application.Features.Comments.Commands.Add;

namespace SchoolProject.Application.Features.Comments.Validators
{
	public class AddCommentValidator : AbstractValidator<AddCommentCommandRequest>
	{
		public AddCommentValidator()
		{
            RuleFor(post => post.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(500).WithMessage("İçerik 500 karakterden az olmalıdır.");

        }
    }
}

