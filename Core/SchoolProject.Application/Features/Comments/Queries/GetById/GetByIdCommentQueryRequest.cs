using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Queries.GetById
{
	public class GetByIdCommentQueryRequest :IRequest<IDataResult<GetByIdCommentDTO>>
	{
		public string Id { get; set; }
	}
}

