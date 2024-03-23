using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersComments
{
	public class GetByIdUsersCommentsQueryResponse : IRequest<IDataResult<GetAllCommentsDTO>>, IDTO
	{
        public List<GetAllCommentsDTO> usersComments { get; set; }
        public int totalCount { get; set; }
    }
}

