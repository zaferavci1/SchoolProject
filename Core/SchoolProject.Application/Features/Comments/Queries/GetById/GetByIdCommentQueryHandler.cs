using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQueryRequest, IDataResult<GetByIdCommentDTO>>
    {

        private ICommentService _commentService;
        public GetByIdCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IDataResult<GetByIdCommentDTO>> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdCommentDTO getByIdCommentDTO = await _commentService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdCommentDTO>("Yorum Getirildi", getByIdCommentDTO);
        }
    }
}

