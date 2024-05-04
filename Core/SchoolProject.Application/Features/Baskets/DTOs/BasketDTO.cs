using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class BasketDTO :IDTO
    {
        public string UserId { get; set; }
        public string Id { get; set; }
		public string BasketName { get; set; }
		public DateTime CreatedDate { get; set; }
		public int LikeCount { get; set; }
	}
}

