using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Queries.GetById;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQueryRequest, IDataResult<GetByIdCommentDTO>>
    {

        private ICommentService _commentService;
        CommentBusinessRules _commentBusinessRules;

        public GetByIdCommentQueryHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules)
        {
            _commentService = commentService;
            _commentBusinessRules = commentBusinessRules;
        }
        public async Task<IDataResult<GetByIdCommentDTO>> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
        {
            await _commentBusinessRules.IsCommentExistAsync(request.Id);
            await _commentBusinessRules.IsCommentActiveAsync(request.Id);

            GetByIdCommentDTO getByIdCommentDTO = await _commentService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdCommentDTO>("Yorum Getirildi", getByIdCommentDTO);
        }
    }
}

