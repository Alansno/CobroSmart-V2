using CobroSmart.Application.IServices;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Mappers;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
using CobroSmart.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employees> _employeeRepository;
        private readonly IDbContextFactory<CobroSmartContext> _contextFactory;
        private readonly IRepository<User> _userRepository;
        private readonly Util _util;
        private readonly CobroSmartContext _context;
        private readonly IRoleService _roleService;
        private readonly EmployeeMapper _mapper;
        public EmployeeService(IRepository<Employees> employeeRepository, IDbContextFactory<CobroSmartContext> contextFactory, IRepository<User> userRepository, Util util, CobroSmartContext context, IRoleService roleService, EmployeeMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _contextFactory = contextFactory;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
            _roleService = roleService;
            _util = util;
        }

        public async Task<Result<EmployeeDto>> Create(EmployeeDto employeeDto, int companyId)
        {
            var loadUsername = FindUsername(employeeDto.Username);
            var loadEmail = FindEmail(employeeDto.EmailEmployee);

            await Task.WhenAll(loadUsername, loadEmail);

            var resultUsername = await loadUsername;
            var resultEmail = await loadEmail;

            if (!resultUsername.IsSuccess || !resultEmail.IsSuccess)
                return Result<EmployeeDto>.Failure(resultUsername.Error ?? resultEmail.Error);

            return await FindRoleById()
                .BindAsync(async role =>
                {
                    var passwordResult = HashPassword(employeeDto.Password);
                    return passwordResult.IsSuccess ? await Save(employeeDto, role.Id, passwordResult.Value, companyId) : Result<EmployeeDto>.Failure(passwordResult.Error);
                });
        }

        public async Task<Result<bool>> FindEmail(string email)
        {
            using var contextt = _contextFactory.CreateDbContext();
            var theEmail = await contextt.Employees
            .Where(u => u.EmailEmployee == email).Select(u => u.Id).FirstOrDefaultAsync();
            return theEmail == 0 ? Result<bool>.Success(true) : Result<bool>.Failure($"Email: {email} is already in use");
        }

        public async Task<Result<FindRoleWithIdAndName>> FindRoleById()
        {
            int id = 3;
            return await _roleService.FindById(id);
        }

        public async Task<Result<bool>> FindUsername(string username)
        {
            using var contextt = _contextFactory.CreateDbContext();
            var theUsername = await contextt.Users
            .Where(u => u.Username == username).Select(u => u.Id).FirstOrDefaultAsync();
            return theUsername == 0 ? Result<bool>.Success(true) : Result<bool>.Failure($"Username: {username} is already in use");
        }

        public Result<PasswordResult> HashPassword(string password)
        {
            var hash = _util.HashPassword(password, out byte[] salt);
            return Result<PasswordResult>.Success(new PasswordResult { Hash = hash, Salt = salt });
        }

        public async Task<Result<EmployeeDto>> Save(EmployeeDto employeeDto, int roleId, PasswordResult passwordResult, int companyId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = _mapper.MapToUser(employeeDto, roleId, passwordResult.Hash, passwordResult.Salt);
                    var userId = await _userRepository.Save(user);

                    var employee = _mapper.MapToEmployee(employeeDto, userId.Value.Id, companyId);
                    await _employeeRepository.Save(employee);
                    transaction.Commit();

                    return Result<EmployeeDto>.Success(_mapper.MapToDto(user, employee));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    return Result<EmployeeDto>.Failure($"{ex.Message}");
                }
            }
        }
    }
}
