using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } //Owner, Admin, Cashier
        public string RoleDescription { get; set; } = string.Empty;
    }
}
