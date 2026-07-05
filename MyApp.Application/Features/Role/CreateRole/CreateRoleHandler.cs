using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Role.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
    {
        private readonly IRoleRepository roleRepository;

        public CreateRoleHandler(IRoleRepository roleRepo)
        {
            roleRepository = roleRepo;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = new Roles
                {
                    RoleName = request.RoleName,
                    RoleDescription = request.RoleDescription,
                };

                await roleRepository.AddRoleAsync(role);
                return new CreateRoleResponse
                {
                    IsSuccess = true,
                    Message = "Role added successfully."
                };
            }
            catch (Exception ex)
            {
                return new CreateRoleResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
