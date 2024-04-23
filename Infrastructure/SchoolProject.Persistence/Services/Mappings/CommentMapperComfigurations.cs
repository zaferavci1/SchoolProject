using System;
using Mapster;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services.Mappings
{
	public class CommentMapperComfigurations : IRegister
	{

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateCommentDTO, User>().Map(dest => dest.IsActive, src => true);
        }
    }
}

