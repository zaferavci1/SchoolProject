using System;
namespace SchoolProject.Domain.Entities
{
    public class PublicProfile : BaseEntity
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<PublicProfile> Followers { get; set; }
        public List<PublicProfile> Follows { get; set; }
        public List<Post> Posts { get; set; }
    }
}

