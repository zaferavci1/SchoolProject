using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetById
{
	public class GetByIdPostQueryHandler : IRequestHandler<GetByIdQueryPostRequest, IDataResult<GetByIdPostDTO>>
	{
        private IPostService _postService;
        public GetByIdPostQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<GetByIdPostDTO>> Handle(GetByIdQueryPostRequest request, CancellationToken cancellationToken)
        {
            GetByIdPostDTO getByIdPostDTO = await _postService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdPostDTO>("Gönderi getirildi.", getByIdPostDTO);
        }
    }
}

