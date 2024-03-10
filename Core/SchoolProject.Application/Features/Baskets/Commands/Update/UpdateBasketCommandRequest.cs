using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Update
{
	public class UpdateBasketCommandRequest :IRequest<IDataResult<BasketDTO>>
	{
        public string Id { get; set; }
        public string BasketName { get; set; }
    }
}

