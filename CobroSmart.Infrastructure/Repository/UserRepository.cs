using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
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

        public async Task<Result<bool>> Delete(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
                 return Result<bool>.Failure("User not found");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Result<bool>.Success(true);
        }

        public async Task<Result<User>> FindById(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
                return Result<User>.Failure("User not found");

            return Result<User>.Success(user);
        }

        public IQueryable<User> GetAll()
        {
           return _context.Users;
        }

        public async Task<Result<User>> Save(User model)
        {
            if (model == null)
                return Result<User>.Failure("Model was found");

            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return Result<User>.Success(model);
        }

        public async Task<Result<bool>> SoftDelete(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
                return Result<bool>.Failure("User not found");

                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> Update(User model)
        {
            if (model == null)
                return Result<bool>.Failure("model is empty");

            var existingUser = await _context.Users.FindAsync(model.Id);
            if (existingUser == null)
                return Result<bool>.Failure("User was not found");

                _context.Users.Update(model);
                await _context.SaveChangesAsync();
                return Result<bool>.Success(true);
        }
    }
}
