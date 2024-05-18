using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Posts.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Add
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        PostBusinessRules _postBusinessRules;
        UserBusinessRules _userBusinessRules;

        public AddCommentCommandHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules, PostBusinessRules postBusinessRules, UserBusinessRules userBusinessRules)
        {
            _commentService = commentService;
            _postBusinessRules = postBusinessRules;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<IDataResult<CommentDTO>> Handle(AddCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _postBusinessRules.IsPostExistAsync(request.PostId);
            await _postBusinessRules.IsPostActiveAsync(request.PostId);
            CommentDTO commentDTO = await _commentService.AddAsync(request.Adapt<AddCommentDTO>());
            var data = new SuccessDataResult<CommentDTO>(request.PostId + " 'a yorum eklendi", commentDTO);
            return data;
        }
    }
}

