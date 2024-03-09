using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Context
{
	public class SchoolProjectDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<GetAllPostDTO> PublicProfiles { get; set; }
		public DbSet<Crypto> Cryptos { get; set; }
		public DbSet<Post>  Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Basket> Baskets { get; set; }
        public SchoolProjectDbContext(DbContextOptions<SchoolProjectDbContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();
            foreach (EntityEntry<BaseEntity> data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                    data.Entity.IsActive = true;
                }
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.UtcNow;
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }

}

