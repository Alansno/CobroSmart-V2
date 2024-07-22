using CobroSmart.Domain.Builder;
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
        [HttpGet]
        [Route("/greeting")]
        public IActionResult Greeting()
        {
            var response = new ResponseBuild()
            .SetSuccess(true)
            .SetMessage("Saludo desde controlador")
            .SetStatus(System.Net.HttpStatusCode.Created)
            .Build();

            return Ok(response);
        }
    }
}
