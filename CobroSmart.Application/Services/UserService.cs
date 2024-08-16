using CobroSmart.Application.IServices;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Custom.Results;
using CobroSmart.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CobroSmart.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Employees> _employeeRepository;
        public UserService(IRepository<User> userRepository, IRepository<Company> companyRepository, IRepository<Employees> employeeRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<Result<User>> FindByUsername(string Username)
        {
            var username = await _userRepository.GetAll().Where(u => u.Username == Username).FirstOrDefaultAsync();
            return Result<User>.Success(username)
                .Ensure(username => username != null, "Username not found");
        }

        public async Task<Result<CompanyIdAndEmployeeId>> IsCompanyOrEmployee(string role, int userId)
        {
            if (role != null && role == "Company")
            {
                var company = await _companyRepository.GetAll().Where(u => u.UserId == userId)
                    .Select(u => new CompanyIdAndEmployeeId { CompanyId = u.Id, EmployeeId = null }).FirstOrDefaultAsync();
                return Result<CompanyIdAndEmployeeId>.Success(company).Ensure(company => company != null, "Company not found");
            }
            var employee = await _employeeRepository.GetAll().Where(u => u.UserId == userId)
            .Select(u => new CompanyIdAndEmployeeId { CompanyId = u.CompanyId, EmployeeId = u.Id }).FirstOrDefaultAsync();
            return Result<CompanyIdAndEmployeeId>.Success(employee)
                .Ensure(employee => employee != null, "Employee not found");
        }
    }
}
