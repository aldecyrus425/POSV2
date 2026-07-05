using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Role.CreateRole
{
    public class CreateRoleCommand : IRequest<CreateRoleResponse>
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; } = string.Empty;
    }
}
