using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Delete
{
	public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, IDataResult<PostDTO>>
	{
        private IPostService _postService;
        PostBusinessRules _postBusinessRules;

        public DeletePostCommandHandler(IPostService postService, PostBusinessRules postBusinessRules)
        {
            _postService = postService;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<IDataResult<PostDTO>> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postBusinessRules.IsPostExist(request.Id);
            await _postBusinessRules.IsPostActive(request.Id);
            PostDTO postDTO = await _postService.DeleteAsync(request.Id);
            return new SuccessDataResult<PostDTO>(postDTO.Title + "Post silindi.", postDTO);
        }
    }
}

