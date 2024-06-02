using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using SLG.Shared.DTOs;
using SLG.Application.Exception;
using Microsoft.Extensions.Logging;
using SLG.Domain.Entities;
using SLG.Application.Features.Users.Commands.CreateUsers;
using SLG.Application.Features.Users.Commands;
using SLG.Application.Features.Users.Queries.GetUserByusernameandpassword;


namespace SLG.WebApi.Controllers
{
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public LoginController(IMediator mediator, IMapper mapper, ILogger<LoginController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                var usr = new CreateUsersCommand(userDTO.Username, userDTO.HashPassword, userDTO.Role, userDTO.StoreLocationId);
                await _mediator.Send(usr);

            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();


            }
            _logger.LogInformation("CreateUser method is called.New User has been created.");
            return Ok(userDTO);

        }


        [HttpGet("GetUserByusername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CheckUserCredentials(string username, string password)
        {

            try
            {
                var result = await _mediator.Send(new GetUserByNamePwdQuery() { Username = username,HashPassword=password });
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);

                _logger.LogInformation("GetUserByusername method is called.");

                return NotFound();


            }

        }
    }
        
}
