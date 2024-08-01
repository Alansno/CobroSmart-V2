using CobroSmart.Application.IServices;
using CobroSmart.Domain.Models;
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
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<User>> FindByUsername(string Username)
        {
            var username = await _userRepository.GetAll().Where(u => u.Username == Username).FirstOrDefaultAsync();
            return Result<User>.Success(username)
                .Ensure(username => username != null, "Username not found");
        }
    }
}
