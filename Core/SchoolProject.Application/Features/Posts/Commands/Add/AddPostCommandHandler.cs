using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Add
{
	public class AddPostCommandHandler : IRequestHandler<AddPostCommandRequest, IDataResult<PostDTO>>
    {
        IPostService _postService;

        public AddPostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<PostDTO>> Handle(AddPostCommandRequest request, CancellationToken cancellationToken)
        {
            PostDTO postDTO = await _postService.AddAsync(request.Adapt<AddPostDTO>());
            var data = new SuccessDataResult<PostDTO>(postDTO.Title + "Post eklendi.", postDTO);
            return data;
        }
    }
}

