using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly CobroSmartContext _context;
        public RoleRepository(CobroSmartContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int Id)
        {
            var role = await _context.Roles.FindAsync(Id) ?? throw new NotFoundException("Role not was found");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> FindById(int Id)
        {
            var role = await _context.Roles.FindAsync(Id) ?? throw new NotFoundException("Role not was found");

            return role;
        }

        public async Task<IQueryable<Role>> GetAll()
        {
            IQueryable<Role> roles = _context.Roles;
            return roles;
        }

        public async Task<Role> Save(Role model)
        {
            if (model == null)
                throw new NotFoundException(nameof(model));

            var role = await _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<bool> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
