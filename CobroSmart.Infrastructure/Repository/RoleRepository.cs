using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
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
        public async Task<Result<bool>> Delete(int Id)
        {
            var role = await _context.Roles.FindAsync(Id);
            if (role == null)
                return Result<bool>.Failure("Role not was found");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }

        public async Task<Result<Role>> FindById(int Id)
        {
            var role = await _context.Roles.FindAsync(Id);
            if (role == null)
                return Result<Role>.Failure("Role not was found");

            return Result<Role>.Success(role);
        }

        public IQueryable<Role> GetAll()
        {
            return _context.Roles;
        }

        public async Task<Result<Role>> Save(Role model)
        {
            if (model == null)
                return Result<Role>.Failure("Model is empty");

            var role = await _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
            return Result<Role>.Success(model);
        }

        public Task<Result<bool>> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
