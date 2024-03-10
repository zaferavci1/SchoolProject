using System;
using MediatR;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetById
{
	public class GetByIdUserQueryRequest : IRequest<IDataResult<GetByIdUserDTO>>
	{
		public string Id { get; set; }
	}
}

