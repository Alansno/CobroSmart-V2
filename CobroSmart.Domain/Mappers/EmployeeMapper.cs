using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Mappers
{
    public class EmployeeMapper
    {
        public User MapToUser(EmployeeDto employeeDto, int roleId, string Hash, byte[] salt)
        {
            return new User
            {
                Username = employeeDto.Username,
                Password = Hash,
                Salt = salt,
                RoleId = roleId
            };
        }

        public Employees MapToEmployee(EmployeeDto employeeDto, int userId, int companyId)
        {
            return new Employees
            {
                NameEmployee = employeeDto.NameEmployee,
                EmailEmployee = employeeDto.EmailEmployee,
                PhoneNumberEmployee = employeeDto.PhoneNumberEmployee,
                UserId = userId,
                CompanyId = companyId
            };
        }

        public EmployeeDto MapToDto(User user, Employees employees)
        {
            return new EmployeeDto
            {
                Username = user.Username,
                Password = "IsSecret",
                NameEmployee = employees.NameEmployee,
                EmailEmployee = employees.EmailEmployee,
                PhoneNumberEmployee = employees.PhoneNumberEmployee,
            };
        }
    }
}
