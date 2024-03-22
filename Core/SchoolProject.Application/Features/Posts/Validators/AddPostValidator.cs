﻿using System;
using FluentValidation;
using SchoolProject.Application.Features.Posts.Commands.Add;

namespace SchoolProject.Application.Features.Posts.Validators
{
	public class AddPostValidator : AbstractValidator<AddPostCommandRequest>
	{
		public AddPostValidator()
        {
            RuleFor(post => post.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .Length(2, 100).WithMessage("Başlık 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(post => post.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(500).WithMessage("İçerik 500 karakterden az olmalıdır.");
        }
	}
}

