using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class GetByIdCommentDTO : IDTO
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Id { get; set; }
        public int LikeCount { get; set; }
        public string Content { get; set; }
        public List<CommentDTO> ReplyComments { get; set; }
    }
}

