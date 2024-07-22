using CobroSmart.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Application.IServices
{
    public interface ICompanyService
    {
        Task<UserDto> Create(UserDto userDto);
    }
}
