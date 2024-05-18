using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class CommentDTO : IDTO
    {
        public string UserId { get; set; }
        public string OwnersName { get; set; }
        public string PostId { get; set; }
        public string Id { get; set; }
        public int LikeCount { get; set; }
        public string Content { get; set; }
        public byte ProfilePictureId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

