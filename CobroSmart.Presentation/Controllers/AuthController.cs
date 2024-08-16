using CobroSmart.Application.IServices;
using CobroSmart.Domain.Builder;
using CobroSmart.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CobroSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseBuild _response;
        public AuthController(IAuthService authService, ResponseBuild response)
        {
            _authService = authService;
            _response = response;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] AuthDto authDto)
        {
            var auth = await _authService.Authenticate(authDto);
            if (auth.IsSuccess)
                return Ok(_response.SetSuccess(true)
                       .SetStatus(System.Net.HttpStatusCode.OK)
                       .SetMessage("User authenticated succesfully")
                       .SetData(auth.Value)
                       .Build());

            return BadRequest(auth.Error);
        }
    }
}
