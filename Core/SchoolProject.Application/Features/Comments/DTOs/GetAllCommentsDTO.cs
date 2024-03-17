using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class GetAllCommentsDTO : IDTO
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Id { get; set; } 
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public List<CommentDTO> ReplyComments { get; set; }
    }
}

