using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLG.Application.Exception;
using SLG.Application.Features.ComplaintCategory.Queries;
using SLG.Application.Features.Complaints.Queries.GetAllComplaints;

namespace SLG.WebApi.Controllers
{
    public class ComplaintCategoryController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ComplaintCategoryController(IMediator mediator, IMapper mapper, ILogger<LoginController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllComplaintsCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllComplaintsCategories()
        {
            try
            {
                var result = await _mediator.Send(new GetAllComplaintCategoryQuery());
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetAllComplaintsCategories method is called.");

                return NotFound();


            }

        }
    }
}
