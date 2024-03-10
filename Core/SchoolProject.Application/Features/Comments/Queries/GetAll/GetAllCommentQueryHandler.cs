using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolProject.Application.Features.Comments.Queries.GetAll
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQueryRequest, IDataResult<GetAllCommentQueryResponse>>
    {

        private ICommentService _commentService;
        public GetAllCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IDataResult<GetAllCommentQueryResponse>> Handle(GetAllCommentQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllCommentsDTO> getAllCommentsDTO ,int totalCount) data = await _commentService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllCommentQueryResponse>("Data Listelendi", new GetAllCommentQueryResponse() {  Comments = data.getAllCommentsDTO , TotalCommentCount = data.totalCount});
        }
    }
}

