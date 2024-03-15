﻿
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Baskets.Commands.Add;
using SchoolProject.Application.Features.Baskets.Commands.Delete;
using SchoolProject.Application.Features.Baskets.Commands.Update;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Queries.GetAll;
using SchoolProject.Application.Features.Baskets.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBasketCommandRequest addBasketCommandRequest)
        {
            IDataResult<BasketDTO> response = await _mediator.Send(addBasketCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBasketCommandRequest updateBasketCommandRequest)
        {
            IDataResult<BasketDTO> response = await _mediator.Send(updateBasketCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketCommandRequest deleteBasketCommandRequest)
        {
            IDataResult<BasketDTO> response = await _mediator.Send(deleteBasketCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBasketQueryRequest getByIdBasketQueryRequest)
        {
            IDataResult<GetByIdBasketDTO> response = await _mediator.Send(getByIdBasketQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBasketsQueryRequest getAllBasketQueryRequest)
        {
            IDataResult<GetAllBasketsQueryResponse> response = await _mediator.Send(getAllBasketQueryRequest);
            return Ok(response);
        }
    }
}
