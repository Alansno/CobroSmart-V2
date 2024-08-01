using CobroSmart.Application.IServices;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Mappers;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
using CobroSmart.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IDbContextFactory<CobroSmartContext> _contextFactory;
        private IRepository<Company> _companyRepository;
        private readonly CompanyMapper _mapper;
        private readonly Util _util;
        private readonly CobroSmartContext _context;
        private readonly IRoleService _roleService;
        private readonly IRepository<User> _userRepository;
        public CompanyService(IDbContextFactory<CobroSmartContext> contextFactory, IRepository<Company> companyRepository, CompanyMapper mapper, Util util, CobroSmartContext context, IRoleService roleService, IRepository<User> userRepository)
        {
            _contextFactory = contextFactory;
            _companyRepository = companyRepository;
            _mapper = mapper;
            _util = util;
            _context = context;
            _roleService = roleService;
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Create(UserDto userDto)
        {
            var loadUsername = FindUsername(userDto.Username);
            var loadEmail = FindEmail(userDto.EmailCompany);

            await Task.WhenAll(loadUsername, loadEmail);

            var resultUsername = await loadUsername;
            if (!resultUsername.IsSuccess) return Result<UserDto>.Failure(resultUsername.Error);

            var resultEmail = await loadEmail;
            if (!resultEmail.IsSuccess) return Result<UserDto>.Failure(resultEmail.Error);

            var toRole = await FindRoleById();
            if (!toRole.IsSuccess) return Result<UserDto>.Failure(toRole.Error);

            var toHash = HashPassword(userDto.Password);
            if (!toHash.IsSuccess) return Result<UserDto>.Failure(toHash.Error);

            return await Save(userDto, toRole.Value.Id, toHash.Value.Hash, toHash.Value.Salt);
        }

        public async Task<Result<bool>> FindUsername(string username)
        {
            using var contextt = _contextFactory.CreateDbContext();
            var theUsername = await contextt.Users
            .Where(u => u.Username == username).Select(u => u.Id).FirstOrDefaultAsync();
            return theUsername == 0 ? Result<bool>.Success(true) : Result<bool>.Failure($"Username: {username} is already in use");
        }

        public async Task<Result<bool>> FindEmail(string email)
        {
            using var contextt = _contextFactory.CreateDbContext();
            var theEmail = await contextt.Companies
            .Where(e => e.EmailCompany == email).Select(e => e.Id).FirstOrDefaultAsync();
            return theEmail == 0 ? Result<bool>.Success(true) : Result<bool>.Failure($"Email: {email} is already in use");
        }

        public async Task<Result<FindRoleWithIdAndName>> FindRoleById()
        {
            int id = 3;
            return await _roleService.FindById(id);
        }

        public Result<PasswordResult> HashPassword(string password)
        {
            var hash =  _util.HashPassword(password, out byte[] salt);
            return Result<PasswordResult>.Success(new PasswordResult { Hash = hash, Salt = salt});
        }

        public async Task<Result<UserDto>> Save(UserDto userDto, int roleId, string hash, byte[] salt)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = _mapper.MapToUser(userDto, roleId, hash, salt);
                    var userId = await _userRepository.Save(user);

                    var company = _mapper.MapToCompany(userDto, userId.Value.Id);
                    await _companyRepository.Save(company);
                    transaction.Commit();

                    return Result<UserDto>.Success(_mapper.MapToDto(user, company));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    return Result<UserDto>.Failure($"{ex.Message}");
                }
            }
        }
    }
}
