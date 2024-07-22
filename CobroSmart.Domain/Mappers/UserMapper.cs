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
    public partial class UserMapper
    {
        public partial User MapToUser(UserDto userDto);
        public partial UserDto MapToDto(User user);
    }
}
