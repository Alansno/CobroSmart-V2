using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly CobroSmartContext _context;
        public UserRepository(CobroSmartContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
                var user = await _context.Users.FindAsync(Id) ?? throw new NotFoundException("User not was found");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<User> FindById(int Id)
        {
            var user = await _context.Users.FindAsync(Id) ?? throw new NotFoundException("User not was found");

                return user;
        }

        public async Task<IQueryable<User>> GetAll()
        {
            IQueryable<User> users = _context.Users;
            return users;
        }

        public async Task<User> Save(User model)
        {
            if (model == null)
                throw new NotFoundException(nameof(model));

                var user = await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
        }

        public async Task<bool> SoftDelete(int Id)
        {
                var user = await _context.Users.FindAsync(Id) ?? throw new NotFoundException("User not was found");

                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<bool> Update(User model)
        {
            if (model == null)
                throw new NotFoundException(nameof(model));

            var existingUser = await _context.Users.FindAsync(model.Id) ?? throw new NotFoundException("User was not found");

            _context.Users.Update(model);
                await _context.SaveChangesAsync();
                return true;
        }
    }
}
