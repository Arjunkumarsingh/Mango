using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDto _response;
        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterationRequestDto model)
        {
            var error = await _authService.Register(model);
            if (!string.IsNullOrEmpty(error))
            {
                _response.IsSuccess = false;
                _response.Message = error;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto requestDto)
        {
            var loginResponse = await _authService.Login(requestDto);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<ActionResult> AssignRole([FromBody] RegisterationRequestDto model)
        {
            var result = await _authService.AssignRole(model.Email, model.Role);
            if (!result)
            {
                _response.IsSuccess = false;
                _response.Message = "Unable to assign role to user";
                return BadRequest(_response);
            }
            _response.Message = "Role assigned.";
            return Ok(_response);
        }
    }
}
