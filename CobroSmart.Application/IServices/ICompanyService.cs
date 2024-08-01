using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Custom.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface ICompanyService
    {
        Task<Result<UserDto>> Create(UserDto userDto);
        Task<Result<bool>> FindUsername(string username);
        Task<Result<bool>> FindEmail(string email);
        Task<Result<FindRoleWithIdAndName>> FindRoleById();
        Result<PasswordResult> HashPassword(string password);
        Task<Result<UserDto>> Save(UserDto userDto, int roleId, string hash, byte[] salt);
    }
}
