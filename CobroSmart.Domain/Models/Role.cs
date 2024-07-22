using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string NameRole { get; set; }
        public ICollection<User> User {  get; } = new List<User>();
    }
}
