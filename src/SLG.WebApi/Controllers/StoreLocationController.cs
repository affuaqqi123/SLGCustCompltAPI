using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLG.Application.Exception;
using SLG.Application.Features.Complaints.Queries.GetAllComplaints;
using SLG.Application.Features.StoreLocation;

namespace SLG.WebApi.Controllers
{
    public class StoreLocationController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public StoreLocationController(IMediator mediator, IMapper mapper, ILogger<LoginController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllStoreLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStoreLocations()
        {
            try
            {
                var result = await _mediator.Send(new GetAllStoreLocationQuery());
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetAllStoreLocation method is called.");

                return NotFound();


            }

        }
    }
}
