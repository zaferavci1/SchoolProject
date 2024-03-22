using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Queries.GetAll;
using SchoolProject.Application.Features.Users.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts
{
	public class GetByIdUsersPostQueryHandler : IRequestHandler<GetByIdUsersPostsQueryRequest, IDataResult<GetByIdUsersPostsQueryResponse>>
    {
        private readonly IUserService _userService;
        public GetByIdUsersPostQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<GetByIdUsersPostsQueryResponse>> Handle(GetByIdUsersPostsQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllPostsDTO> posts, int totalCount) data = await _userService.GetUsersPostsAsync(request.userId);
            return new SuccessDataResult<GetByIdUsersPostsQueryResponse>("Veriler Listelendi.", new GetByIdUsersPostsQueryResponse()
            {
                totalCount = data.totalCount,
                usersPosts = data.posts
            });
        }
    }
}

