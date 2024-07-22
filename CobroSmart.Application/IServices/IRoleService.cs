using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface IRoleService
    {
        Task<Role> Create(RoleDto roleDto);
        Task<int> FindById(int id);
    }
}
