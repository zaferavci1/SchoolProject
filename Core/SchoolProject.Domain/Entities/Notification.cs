using System;
namespace SchoolProject.Domain.Entities
{
	public class Notification : BaseEntity
    {
        public Guid FirstUserId { get; set; }
        public User FirstUser { get; set; }

        public Guid SecondUserId { get; set; }
        public User SecondUser { get; set; }

        public Guid? PostId { get; set; }
        public Post Post { get; set; }

        public Guid? CommentId { get; set; }
        public Comment Comment { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}

/**
 * 
 * addNotification(user , user) takip etme
 * addNotification(user , user, post , comment)  yorum yapma
 * addNotification(user , user , comment) yorum begenme
 * addNotification(user , user , post) post  begenme
 * 
 * 
*/