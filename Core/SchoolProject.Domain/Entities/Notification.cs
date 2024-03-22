using System;
namespace SchoolProject.Domain.Entities
{
	public class Notification : BaseEntity
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public Guid PostId { get; set; }
        public Guid CommentId { get; set; }
        public string Message { get; set; }
    }
}

/**
 * 
 * addNotification(user , post)
 * addNotification(user , user)
 * addNotification(user , user, post , comment)
 * addNotification(user , user , comment)
 * addNotification(user , user , post)
 * 
 * 
*/