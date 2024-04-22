using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.Commands.Like;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.UnLike
{
	public class UnLikePostCommandHandler : IRequestHandler<UnLikePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;
        PostBusinessRules _postBusinessRules;
        UserBusinessRules _userBusinessRules;

        public UnLikePostCommandHandler(IPostService postService, UserBusinessRules userBusinessRules, PostBusinessRules postBusinessRules)
        {
            _postService = postService;
            _userBusinessRules = userBusinessRules;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<IDataResult<PostDTO>> Handle(UnLikePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserActive(request.UserId);
            await _postBusinessRules.IsPostExist(request.Id);
            await _postBusinessRules.IsPostActive(request.Id);
            await _postBusinessRules.IsPostAllreadyLiked(request.Id, request.UserId);
            PostDTO postDTO = await _postService.UnLikeAsync(request.Id, request.UserId);
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post'u begenildi.", postDTO);
            return data;
        }
    }
}

