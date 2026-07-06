using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public CreateUserHandler(IUserRepository repo, IBranchRepository branchRepo, IUserRoleRepository userRoleRepository)
        {
            _userRepository = repo;
            _branchRepository = branchRepo;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate if the email is duplicate
                var validateEmail = await _userRepository.GetUserByEmail(request.Email);
                if (validateEmail != null)
                {
                    return new CreateUserResponse
                    {
                        IsSuccess = false,
                        Message = "Email already existing."
                    };
                }


                //Validate if the branch is active
                var branch = await _branchRepository.GetBranchByIdAsync(request.BranchId);
                if (branch == null)
                {
                    return new CreateUserResponse
                    {
                        IsSuccess = false,
                        Message = "Branch not found."
                    };
                }


                var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var user = new Users
                {
                    FirstName = request.Firstname,
                    MiddleName = request.Middlename,
                    LastName = request.Lastname,
                    Email = request.Email,
                    PasswordHash = hashPassword,
                    ContactNumber = request.Contact_Num,
                    BranchId = request.BranchId,
                    IsActive = request.Status
                };

                await _userRepository.AddUserAsync(user);

                var userRole = new UserRoles
                {
                    UserId = user.UserId,
                    RoleId = request.RoleId
                };

                await _userRoleRepository.InsertUserRoleAsync(userRole);

                return new CreateUserResponse
                {
                    IsSuccess = true,
                    Message = "User created successfully."
                };
            }
            catch (Exception ex)
            {
                return new CreateUserResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }
    }
}

