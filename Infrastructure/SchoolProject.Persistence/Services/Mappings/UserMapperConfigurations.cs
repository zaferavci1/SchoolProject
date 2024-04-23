using System;
using Mapster;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Features.Users.Commands.Update;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services.Mappings
{
	public class UserMapperConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateUserDTO,User>().Map(dest => dest.Id, src => src.Id);
            config.NewConfig<UpdateUserDTO, User>().Map(dest => dest.IsActive, src => true);
        }
    }
}

