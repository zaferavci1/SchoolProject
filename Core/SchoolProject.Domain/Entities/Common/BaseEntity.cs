using System;
namespace SchoolProject.Domain.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}

