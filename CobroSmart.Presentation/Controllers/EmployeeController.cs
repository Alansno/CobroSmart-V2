using CobroSmart.Application.IServices;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Builder;
using CobroSmart.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CobroSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ResponseBuild _responseBuild;
        public EmployeeController(IEmployeeService employeeService, ResponseBuild responseBuild)
        {
            _employeeService = employeeService;
            _responseBuild = responseBuild;
        }

        [HttpPost]
        [Route("create-employee")]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            var companyId = Util.findUserId(HttpContext);
            var employee = await _employeeService.Create(employeeDto, companyId);

            if (employee.IsSuccess)
                return Ok(_responseBuild
                          .SetSuccess(true)
                          .SetMessage("User with employee role created successfully")
                          .SetData(employee.Value)
                          .SetStatus(System.Net.HttpStatusCode.Created)
                          .Build());

            return BadRequest(employee.Error);
        }
    }
}
