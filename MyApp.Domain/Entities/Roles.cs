using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Roles
    {
        public int RoleId { get; private set; }
        public string RoleName { get; private set; } //Owner, Admin, Cashier
        public string RoleDescription { get; private set; } = string.Empty;
    }
}
