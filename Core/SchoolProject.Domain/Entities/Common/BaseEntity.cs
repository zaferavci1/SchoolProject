using System;
namespace SchoolProject.Domain.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}

