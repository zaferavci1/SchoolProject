using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts
{
	public class GetByIdUsersPostsQueryResponse : IRequest<IDataResult<GetAllPostsDTO>>, IDTO
	{
        public List<GetAllPostsDTO> usersPosts { get; set; }
        public int totalCount { get; set; }

    }
}

