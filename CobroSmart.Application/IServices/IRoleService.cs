using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using CobroSmart.Domain.QueryBase;
using CobroSmart.Infrastructure.Custom.Results;
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
        Task<Result<FindRoleWithIdAndName>> FindById(int id);
    }
}
