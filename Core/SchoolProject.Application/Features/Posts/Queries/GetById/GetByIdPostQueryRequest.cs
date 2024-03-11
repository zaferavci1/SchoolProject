using System;
using MediatR;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetById
{
    public class GetByIdPostQueryRequest : IRequest<IDataResult<GetByIdPostDTO>>
	{
		public string Id { get; set; }
	}
}

