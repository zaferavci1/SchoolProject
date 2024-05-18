using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Add
{
	public class AddPostCommandHandler : IRequestHandler<AddPostCommandRequest, IDataResult<PostDTO>>
    {
        IPostService _postService;
        UserBusinessRules _userBusinessRules;

        public AddPostCommandHandler(IPostService postService, UserBusinessRules userBusinessRules)
        {
            _postService = postService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<PostDTO>> Handle(AddPostCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            PostDTO postDTO = await _postService.AddAsync(request.Adapt<AddPostDTO>());
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post eklendi.", postDTO);
            return data;
        }
    }
}

