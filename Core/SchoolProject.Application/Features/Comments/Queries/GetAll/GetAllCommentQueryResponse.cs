using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Queries.GetAll
{
	public class GetAllCommentQueryResponse : IRequest<IDataResult<GetAllCommentsDTO>>, IDTO
	{
		public List<GetAllCommentsDTO> Comments { get; set; }
        public int TotalCommentCount { get; set; }
    }
}

