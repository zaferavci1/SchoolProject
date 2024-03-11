using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetAll
{
	public class GetAllPostQueryResponse : IRequest<IDataResult<GetAllPostsDTO>>, IDTO
    {
        public List<GetAllPostsDTO> Posts { get; set; }
        public int TotalPostCount { get; set; }
    }
}

