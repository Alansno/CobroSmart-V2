using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Custom.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface IEmployeeService
    {
        Task<Result<EmployeeDto>> Create(EmployeeDto employeeDto, int companyId);
        Task<Result<bool>> FindUsername(string username);
        Task<Result<bool>> FindEmail(string email);
        Task<Result<FindRoleWithIdAndName>> FindRoleById();
        Result<PasswordResult> HashPassword(string password);
        Task<Result<EmployeeDto>> Save(EmployeeDto employeeDto, int roleId, PasswordResult passwordResult, int companyId);
    }
}
