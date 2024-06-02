using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using SLG.Shared.DTOs;
using SLG.Application.Features.Complaints.Commands.CreateComplaints;
using SLG.Application.Exception;
using SLG.Application.Features.Complaints.Queries.GetAllComplaints;
using SLG.Application.Features.Complaints.Queries.GetComplaintsByStoreId;
using SLG.Application.Features.Complaints.Commands.DeleteCustomerComplaint;
using SLG.Application.Features.Complaints.Commands.UpdateComplaint;
using SLG.Application.Features.Complaints.Queries.GetComplaintById;

namespace SLG.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CustomerComplaintController : ControllerBase
    {
        private readonly ILogger<CustomerComplaintController> _logger;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;


        public CustomerComplaintController(IMediator mediator, IMapper mapper, ILogger<CustomerComplaintController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("CreateComplaint")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRecord(CustomersComplaintDto complaintDTO)
        {
            try
            {
                var complaint = new CreateCustomerComplaintCommand(complaintDTO.EmployeeId, complaintDTO.EmployeeName, complaintDTO.FirstName, complaintDTO.SurName, complaintDTO.MobileNumber, complaintDTO.Email, complaintDTO.CustomerAddress1, complaintDTO.CustomerAddress2, complaintDTO.City, complaintDTO.Postalcode, complaintDTO.Sku, complaintDTO.BrandName, complaintDTO.OrderNo, complaintDTO.ComplaintCategoryId, complaintDTO.StoreLocationId, complaintDTO.DateofPurchase, complaintDTO.DateofComplaint, complaintDTO.FaultDetectionDate, complaintDTO.NatureOfComplaint, complaintDTO.RemedyRequestedByCustomer, complaintDTO.ProductImagesId, complaintDTO.Comments, complaintDTO.CreatedBy, complaintDTO.UpdatedBy, complaintDTO.CreationDate, complaintDTO.ModificationDate);
                await _mediator.Send(complaint);

            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();


            }
            _logger.LogInformation("CreateComplaint method is called.New Complaint has been created.");
            return Ok(complaintDTO);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerComplaintCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }

                var result = await _mediator.Send(command);
                if (result)
                    return NoContent();


            }
            catch (NotFoundException ex)
            {

                _logger.LogError(ex.Message);

            }
            return NotFound();
        }

        [HttpGet("GetAllComplaints")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRecord()
        {
            try
            {
                var result = await _mediator.Send(new GetAllComplaintQuery());
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetAllCompalints method is called.");

                return NotFound();


            }

        }


#if !DEBUG
        [Authorize] 
#endif
        [HttpGet("id/{Id}", Name = "GetComplaintsByComplaintId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> FindComplaintById(int Id)
        {

            try
            {
                var result = await _mediator.Send(new GetComplaintByIdQuery() { Id = Id });
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetComplaintsByComplaintId method is called.");

                return NotFound();


            }

        }

       
        [HttpGet("storeId/{Id}", Name ="GetComplaintsByStoreLocation")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCompalintsByStoreLocation(string Id)
        {
            try
            {
                var result = await _mediator.Send(new GetAllComplaintByStoreIdQuery() { StoreLocationId = Id });
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetAllCompalintsByStoreLocation method is called.");

                return NotFound();


            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _mediator.Send(new DeleteCustomerComplaintCommand { Id = Id });
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("Delete complaint method is called.");

                return NoContent();
            }

            return NoContent();
        }

    }
}
