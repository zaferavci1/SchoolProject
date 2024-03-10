using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Add
{
	public class AddBasketCommandRequest : IRequest<IDataResult<BasketDTO>>
    {
        public string BasketName { get; set; }
    }
}

