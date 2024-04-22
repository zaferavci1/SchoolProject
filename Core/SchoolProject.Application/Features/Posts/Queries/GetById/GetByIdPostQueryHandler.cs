using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetById
{
	public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, IDataResult<GetByIdPostDTO>>
	{
        private IPostService _postService;
        readonly PostBusinessRules _postBusinessRules;
        public GetByIdPostQueryHandler(IPostService postService, PostBusinessRules postBusinessRules)
        {
            _postService = postService;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<IDataResult<GetByIdPostDTO>> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {

            await _postBusinessRules.IsPostExist(request.Id);
            await _postBusinessRules.IsPostActive(request.Id);
            GetByIdPostDTO getByIdPostDTO = await _postService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdPostDTO>("Gönderi getirildi.", getByIdPostDTO);
        }
    }
}

