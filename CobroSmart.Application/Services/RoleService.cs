using CobroSmart.Application.IServices;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Mappers;
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

namespace CobroSmart.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;
        private readonly RoleMapper _mapper;
        public RoleService(IRepository<Role> repository, RoleMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Role> Create(RoleDto roleDto)
        {
            var role = _mapper.MapToRole(roleDto);
            await _repository.Save(role);
            return role;
        }

        public async Task<Result<FindRoleWithIdAndName>> FindById(int id)
        {
            var result = await _repository.GetAll().Where(r => r.Id == id).
                Select(r => new FindRoleWithIdAndName { Id = r.Id, NameRole = r.NameRole }).FirstOrDefaultAsync();
            return Result<FindRoleWithIdAndName>.Success(result)
                .Ensure(role => role != null, "Role not found");
        }
    }
}
