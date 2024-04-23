using System;
using Mapster;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services.Mappings
{
    public class PostMapperConfigurations : IRegister
	{
		public PostMapperConfigurations()
		{
		}

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdatePostDTO, User>().Map(dest => dest.IsActive, src => true);
        }
    }
}

