using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Like
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;
        PostBusinessRules _postBusinessRules;
        UserBusinessRules _userBusinessRules;
        public LikePostCommandHandler(IPostService postService, PostBusinessRules postBusinessRules, UserBusinessRules userBusinessRules)
        {
            _postService = postService;
            _postBusinessRules = postBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<PostDTO>> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _postBusinessRules.IsPostExistAsync(request.Id);
            await _postBusinessRules.IsPostActiveAsync(request.Id);
            await _postBusinessRules.IsPostLikedAsync(request.Id,request.UserId);
            PostDTO postDTO = await _postService.LikeAsync(request.Id,request.UserId);
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post'u begenildi.", postDTO);
            return data;
        }
    }
}

