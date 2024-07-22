using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Mappers
{
    public class CompanyMapper
    {
        public User MapToUser(UserDto userDto, int roleId, string Hash, byte[] salt)
        {
            return new User
            {
                Username = userDto.Username,
                Password = Hash,
                Salt = salt,
                RoleId = roleId
            };
        }

        public Company MapToCompany(UserDto userDto, int userId)
        {
            return new Company
            {
                NameCompany = userDto.NameCompany,
                AddressCompany = userDto.AddressCompany,
                EmailCompany = userDto.EmailCompany,
                PhoneNumberCompany = userDto.PhoneNumberCompany,
                TypeCompany = userDto.TypeCompany,
                DateEntry = DateTime.UtcNow,
                UserId = userId,
            };
        }

        public UserDto MapToDto(User user, Company company)
        {
            return new UserDto
            {
                Username = user.Username,
                Password = "IsSecret",
                NameCompany = company.NameCompany,
                AddressCompany = company.AddressCompany,
                EmailCompany = company.EmailCompany,
                PhoneNumberCompany = company.PhoneNumberCompany,
                TypeCompany = company.TypeCompany,
            };
        }
    }
}
