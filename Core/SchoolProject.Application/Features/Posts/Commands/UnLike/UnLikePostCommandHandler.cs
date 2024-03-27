using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.Commands.Like;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.UnLike
{
	public class UnLikePostCommandHandler : IRequestHandler<UnLikePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;

        public UnLikePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<PostDTO>> Handle(UnLikePostCommandRequest request, CancellationToken cancellationToken)
        {
            PostDTO postDTO = await _postService.UnLikeAsync(request.Id, request.UserId);
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post'u begenildi.", postDTO);
            return data;
        }
    }
}

