using Mapster;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services.Mappings
{
    public class BasketMapperConfigurations : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateBasketDTO, User>().Map(dest => dest.IsActive, src => true);
        }
    }
}

