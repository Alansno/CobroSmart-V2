using CobroSmart.Application.IServices;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Domain.Response;
using CobroSmart.Infrastructure.Custom.Results;
using CobroSmart.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly Util _util;

        public AuthService(IUserService userService, IRoleService roleService, Util util)
        {
            _userService = userService;
            _roleService = roleService;
            _util = util;
        }
        public async Task<Result<AuthResponse>> Authenticate(AuthDto authDto)
        {
            return await FindUserByUsername(authDto.Username)
            .BindAsync(async user =>
             {
                var roleResult = LoadRole(user);
                var credentialsResult = VerifyUserCredentials(user, authDto.Password);
                var loadToRole = await roleResult;

                return credentialsResult.IsSuccess && loadToRole.IsSuccess
                    ? GenerateAuthResponse(user, loadToRole.Value)
                    : Result<AuthResponse>.Failure(credentialsResult.Error ?? loadToRole.Error);
            });
        }

        public async Task<Result<User>> FindUserByUsername(string username)
        {
            return await _userService.FindByUsername(username);
        }

        public async Task<Result<FindRoleWithIdAndName>> LoadRole(User user)
        {
            return await _roleService.FindById(user.Id);
        }

        public Result<bool> VerifyUserCredentials(User user, string password)
        {
            var isMatch = _util.VerifyPassword(password, user.Password, user.Salt);
            return Result<bool>.Success(isMatch)
                .Ensure(match => match != false, "Incorrect credentials");
        }

        public Result<AuthResponse> GenerateAuthResponse(User user, FindRoleWithIdAndName toRole)
        {
            var token = _util.GenerateToken(user,toRole.NameRole);
            return Result<AuthResponse>.Success(new AuthResponse
            {
                JWT = token,
                Id = user.Id,
                Username = user.Username,
            }); 
        }

        public async Task<bool> Logout()
        {
            return false;
        }
    }
}
