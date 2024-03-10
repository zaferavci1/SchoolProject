using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
	public class GetByIdCommentQueryRequest :IRequest<IDataResult<GetByIdCommentDTO>>
	{
		public string ıd { get; set; }
	}
}

