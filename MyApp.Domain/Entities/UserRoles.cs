using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class UserRoles
    {
        public int UserRoleId { get; private set; }
        public Users Users { get; private set; }
        public int UserId { get; private set; }
        public Roles Roles { get; private set; }
        public int RoleId { get; private set; }
    }
}
