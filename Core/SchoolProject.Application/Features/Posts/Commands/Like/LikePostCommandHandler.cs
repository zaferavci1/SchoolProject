using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Like
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;
        public LikePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<PostDTO>> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
        {
            PostDTO postDTO = await _postService.LikeAsync(request.Id);
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post'u begenildi.", postDTO);
            return data;
        }
    }
}

