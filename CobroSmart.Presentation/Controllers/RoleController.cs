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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ResponseBuild _responseBuild;
        public RoleController(IRoleService roleService, ResponseBuild responseBuild)
        {
            _roleService = roleService;
            _responseBuild = responseBuild;
        }

        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {
            var role =  await _roleService.Create(roleDto);
            return Ok(_responseBuild.SetMessage("Role was created successfully")
                .SetSuccess(true)
                .SetData(role)
                .SetStatus(System.Net.HttpStatusCode.Created)
                .Build());
        }
    }
}
