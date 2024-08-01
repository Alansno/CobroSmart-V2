using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Custom.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface IUserService
    {
        Task<Result<User>> FindByUsername(string Username);
    }
}
