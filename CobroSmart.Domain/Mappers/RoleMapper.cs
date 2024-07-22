using CobroSmart.Domain.Dtos;
using CobroSmart.Domain.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Mappers
{
    [Mapper]
    public partial class RoleMapper
    {
        public partial Role MapToRole(RoleDto roleDto);
        public partial RoleDto MapToDto(Role role);
    }
}
