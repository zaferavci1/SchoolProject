using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersComments
{
	public class GetByIdUsersCommentsHandler : IRequestHandler<GetByIdUsersCommentsQueryRequest, IDataResult<GetByIdUsersCommentsQueryResponse>> 
    {
        private readonly IUserService _userService;
        UserBusinessRules _userBusinessRules;
        public GetByIdUsersCommentsHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<GetByIdUsersCommentsQueryResponse>> Handle(GetByIdUsersCommentsQueryRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.userId);
            await _userBusinessRules.IsUserActiveAsync(request.userId);
            (List<GetAllCommentsDTO> comments, int totalCount) data = await _userService.GetUsersCommentsAsync(request.userId);
            return new SuccessDataResult<GetByIdUsersCommentsQueryResponse>("Veriler Listelendi.", new GetByIdUsersCommentsQueryResponse()
            {
                totalCount = data.totalCount,
                usersComments = data.comments
            });
        }
    }
}

