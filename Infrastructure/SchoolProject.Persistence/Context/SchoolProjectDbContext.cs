using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Context
{
	public class SchoolProjectDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<User> PublicProfiles { get; set; }

		public DbSet<Crypto> Cryptos { get; set; }

		public DbSet<Post>  Posts { get; set; }

        public DbSet<PostLike> PostLikes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketLike> BasketLikes { get; set; }

        public DbSet<UserFollower> UserFollowers { get; set; }


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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.PhoneNumber)
               .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Mail)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.NickName)
                .IsUnique();

            modelBuilder.Entity<Comment>().
                HasOne(c => c.User).
                WithMany(c => c.Comments).
                HasForeignKey(c => c.UserId).
                OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<UserFollower>().HasOne(uf => uf.Followee).WithMany(uf => uf.Followees).
                HasForeignKey(uf => uf.FolloweeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserFollower>().HasOne(uf => uf.Follower).WithMany(uf => uf.Followers).
                HasForeignKey(uf => uf.FollowerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFollower>().HasKey(uf => new
            {
                uf.FolloweeId,
                uf.FollowerId
            });

            modelBuilder.Entity<PostLike>().
                HasOne(pl => pl.Post).
                WithMany(pl => pl.PostLikes).
                HasForeignKey(pl => pl.PostId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostLike>().
                HasOne(u => u.User).
                WithMany(u => u.PostLikes).
                HasForeignKey(u => u.UserId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostLike>().HasKey(pl => new
            {
                pl.UserId,
                pl.PostId
            });


            modelBuilder.Entity<CommentLike>().
                HasOne(cl => cl.Comment).
                WithMany(cl => cl.CommentLikes).
                HasForeignKey(cl => cl.CommentId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentLike>().
                HasOne(u => u.User).
                WithMany(u => u.CommentLikes).
                HasForeignKey(u => u.UserId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentLike>().HasKey(cl => new
            {
                cl.UserId,
                cl.CommentId
            });

            modelBuilder.Entity<BasketLike>().
                HasOne(bl => bl.Basket).
                WithMany(bl => bl.BasketLikes).
                HasForeignKey(bl => bl.BasketId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BasketLike>().
                HasOne(u => u.User).
                WithMany(u => u.BasketLikes).
                HasForeignKey(u => u.UserId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BasketLike>().HasKey(bl => new
            {
                bl.UserId,
                bl.BasketId
            });
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Post)
                .WithMany()
                .HasForeignKey(n => n.PostId) // Ensure this is pointing to an existing column in the Post table
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Adjust delete behavior based on your requirements

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.FirstUser)
                .WithMany()
                .HasForeignKey(n => n.FirstUserId) // Correct FK to FirstUserId
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.SecondUser)
                .WithMany()
                .HasForeignKey(n => n.SecondUserId) // Correct FK to SecondUserId
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Comment)
                .WithMany()
                .HasForeignKey(n => n.CommentId) // Correct FK to CommentId
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }


    }

}

