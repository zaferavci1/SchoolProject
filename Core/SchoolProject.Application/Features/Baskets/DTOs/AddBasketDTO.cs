﻿using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class AddBasketDTO : IDTO
	{
        public string BasketName { get; set; }
        public string UserId { get; set; }
    }
}

