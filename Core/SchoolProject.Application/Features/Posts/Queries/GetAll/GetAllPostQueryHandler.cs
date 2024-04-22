using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetAll
{
	public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, IDataResult<GetAllPostQueryResponse>>
	{
        IPostService _postService;
        public GetAllPostQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IDataResult<GetAllPostQueryResponse>> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Page < 0 || request.Size < 0)
            {
                throw new Exception("Page or Size cannot be less than 0");
            }
            (List<GetAllPostsDTO> posts, int totalCount) data = await _postService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllPostQueryResponse>("Data Listelendi.", new GetAllPostQueryResponse() { Posts = data.posts, TotalPostCount = data.totalCount });
        }
    }
}

