using CobroSmart.Application.IServices;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Mappers;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Repository;
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
        private IRepository<Company> _companyRepository;
        private readonly CompanyMapper _mapper;
        private readonly Util _util;
        private readonly CobroSmartContext _context;
        private readonly IRoleService _roleService;
        private readonly IRepository<User> _userRepository;
        public CompanyService(IRepository<Company> companyRepository, Util util, CobroSmartContext context, IRoleService roleService, IRepository<User> userRepository)
        {
            _companyRepository = companyRepository;
            _mapper = new CompanyMapper();
            _util = util;
            _context = context;
            _roleService = roleService;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Create(UserDto userDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var role = await _roleService.FindById(3);
                    if (role == 0) throw new NotFoundException($"Role with ID {3} was not found");

                    var Hash = _util.HashPassword(userDto.Password, out byte[] salt);

                    var user = _mapper.MapToUser(userDto, role, Hash, salt);
                    var userId = await _userRepository.Save(user);
                    var company = _mapper.MapToCompany(userDto, userId.Id);
                    await _companyRepository.Save(company);
                    transaction.Commit();

                    var userDetails = _mapper.MapToDto(user, company);
                    return userDetails;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new DbUpdateConcurrencyException("Something went wrong");
                }
            }
        }
    }
}
