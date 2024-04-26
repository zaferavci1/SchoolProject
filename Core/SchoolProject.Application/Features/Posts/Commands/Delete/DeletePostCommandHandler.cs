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
            await _postBusinessRules.IsPostExistAsync(request.Id);
            await _postBusinessRules.IsPostActiveAsync(request.Id);
            await _postBusinessRules.IsOwnerCorrectAsync(request.Id,request.UserId);
            PostDTO postDTO = await _postService.DeleteAsync(request.Id);
            return new SuccessDataResult<PostDTO>(postDTO.Title + "Post silindi.", postDTO);
        }
    }
}

