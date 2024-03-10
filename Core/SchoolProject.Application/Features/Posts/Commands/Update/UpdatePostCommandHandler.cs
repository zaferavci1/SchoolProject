using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, IDataResult<PostDTO>>
    {
        private IPostService _postService;

        public UpdatePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<PostDTO>> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            PostDTO postDTO = await _postService.UpdateAsync(new() { Id = request.Id, Content = request.Content, IsActive = request.IsActive, Title = request.Title });
            return new SuccessDataResult<PostDTO>(postDTO.Title + "Gönderi Güncellendi.", postDTO);
        }
    }
}

