using CobroSmart.Application.IServices;
using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Mappers;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Repository;
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
        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
            _mapper = new RoleMapper();
        }

        public async Task<Role> Create(RoleDto roleDto)
        {
            var role = _mapper.MapToRole(roleDto);
            await _repository.Save(role);
            return role;
        }

        public async Task<int> FindById(int id)
        {
            var byId = await _repository.GetAll();
            return byId.Where(r => r.Id == id).Select(r => r.Id).FirstOrDefault();
        }
    }
}
