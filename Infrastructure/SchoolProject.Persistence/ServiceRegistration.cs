using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Application.Abstraction.Repository.Notifications;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Abstraction.Token;
using SchoolProject.Persistence.Configurations;
using SchoolProject.Persistence.Context;
using SchoolProject.Persistence.Repositories.Baskets;
using SchoolProject.Persistence.Repositories.Comments;
using SchoolProject.Persistence.Repositories.Notificationss;
using SchoolProject.Persistence.Repositories.Posts;
using SchoolProject.Persistence.Repositories.Users;
using SchoolProject.Persistence.Services;
using SchoolProject.Infrastructure.Services.Token;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Features.Posts.Rules;
using Mapster;
using System.Reflection;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Abstraction.Repository.Cryptos;
using SchoolProject.Persistence.Repositories.Cryptos;

namespace SchoolProject.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
            Configuration.Configure(configuration);
            services.AddDbContext<SchoolProjectDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IBasketService,BasketService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPublicProfileService, PublicProfileService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<ICryptoService, CryptoService>();


            services.AddScoped<ICommentCommandRepository, CommentCommandRepository>();
            services.AddScoped<ICommentQueryRepository, CommentQueryRepository>();

            services.AddScoped<IPostCommandRepository, PostCommandRepository>();
            services.AddScoped<IPostQueryRepository, PostQueryRepository>();

            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();


            services.AddScoped<IBasketCommandRepository, BasketCommandRepository>();
            services.AddScoped<IBasketQueryRepository, BasketQueryRepository>();


            services.AddScoped<INotificationCommandRepository, NotificationCommandRepository>();
            services.AddScoped<INotificationQueryRepository, NotificationQueryRepository>();

            services.AddScoped<ICryptoCommandRepository, CryptoCommandRepository>();
            services.AddScoped<ICryptoQueryRepository, CryptoQueryRepository>();

            services.AddScoped<UserBusinessRules, UserBusinessRules>();
            services.AddScoped<PostBusinessRules, PostBusinessRules>();
            services.AddScoped<CommentBusinessRules, CommentBusinessRules>();
            services.AddScoped<BasketBusinessRules, BasketBusinessRules>();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            services.AddDataProtection();
        }
	}
}

