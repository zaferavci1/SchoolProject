using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Queries.GetAll;
using SchoolProject.Application.Features.Users.Queries.GetById;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts
{
	public class GetByIdUsersPostQueryHandler : IRequestHandler<GetByIdUsersPostsQueryRequest, IDataResult<GetByIdUsersPostsQueryResponse>>
    {
        private readonly IUserService _userService;
        UserBusinessRules _userBusinessRules;
        public GetByIdUsersPostQueryHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<GetByIdUsersPostsQueryResponse>> Handle(GetByIdUsersPostsQueryRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.userId);
            await _userBusinessRules.IsUserActiveAsync(request.userId);
            (List<GetAllPostsDTO> posts, int totalCount) data = await _userService.GetUsersPostsAsync(request.userId);
            return new SuccessDataResult<GetByIdUsersPostsQueryResponse>("Veriler Listelendi.", new GetByIdUsersPostsQueryResponse()
            {
                totalCount = data.totalCount,
                usersPosts = data.posts
            });
        }
    }
}

