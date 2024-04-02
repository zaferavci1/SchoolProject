using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.PublicProfiles.Queries.GetById;
using SchoolProject.Application.Utilities.Common;


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

