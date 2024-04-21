using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetAll
{
	public class GetAllUserQueryResponse : IRequest<IDataResult<GetAllUsersDTO>>, IDTO
	{
		public List<GetAllUsersDTO> UsersDTOs { get; set; }
		public int TotalUserCount { get; set; }
	}
}

