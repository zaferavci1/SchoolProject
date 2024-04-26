using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, IDataResult<PostDTO>>
    {
        private IPostService _postService;
        PostBusinessRules _postBusinessRules;

        public UpdatePostCommandHandler(IPostService postService, PostBusinessRules postBusinessRules)
        {
            _postService = postService;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<IDataResult<PostDTO>> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postBusinessRules.IsPostExistAsync(request.Id);
            await _postBusinessRules.IsPostActiveAsync(request.Id);
            await _postBusinessRules.IsOwnerCorrectAsync(request.Id,request.UserId);
            PostDTO postDTO = await _postService.UpdateAsync(request.Adapt<UpdatePostDTO>());
            return new SuccessDataResult<PostDTO>(postDTO.Title + "Gönderi Güncellendi.", postDTO);
        }
    }
}

