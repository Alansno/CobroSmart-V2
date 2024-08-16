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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ResponseBuild _responseBuild;
        public CompanyController(ICompanyService companyService, ResponseBuild responseBuild)
        {
            _companyService = companyService;
            _responseBuild = responseBuild;
        }

        [HttpPost]
        [Route("create-company")]
        public async Task<IActionResult> CreateCompanyUser([FromBody] UserDto userDto)
        {
            var save = await _companyService.Create(userDto);
            if (save.IsSuccess)
                return Ok(_responseBuild.SetSuccess(true)
                       .SetStatus(System.Net.HttpStatusCode.Created)
                       .SetMessage("User with Company role was created successfully")
                       .SetData(save.Value)
                       .Build());

            return BadRequest(save.Error);
        }
    }
}
