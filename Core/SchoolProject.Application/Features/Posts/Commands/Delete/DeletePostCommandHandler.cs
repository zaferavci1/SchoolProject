using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Delete
{
	public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;

        public DeletePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<PostDTO>> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            PostDTO postDTO = await _postService.DeleteAsync(request.Id);
            return new SuccessDataResult<PostDTO>(postDTO.Title + "Post silindi.", postDTO);
        }
    }
}

