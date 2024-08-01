using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Domain.Response;
using CobroSmart.Infrastructure.Custom.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> Authenticate(AuthDto authDto);
        Task<Result<User>> FindUserByUsername(string username);
        Task<Result<FindRoleWithIdAndName>> LoadRole(User user);
        Result<bool> VerifyUserCredentials(User user, string password);
        Result<AuthResponse> GenerateAuthResponse(User user, FindRoleWithIdAndName toRole);
        Task<bool> Logout();
    }
}
