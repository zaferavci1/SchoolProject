
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.PublicProfiles.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PublicProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublicProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPublicProfileRequest getByIdPublicProfileQueryRequest)
        {
            IDataResult<GetByIdPublicProfileDTO> response = await _mediator.Send(getByIdPublicProfileQueryRequest);
            return Ok(response);
        }

        
    }
}

