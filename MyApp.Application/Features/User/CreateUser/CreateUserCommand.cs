using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string Contact_Num {  get; set; } = string.Empty;
        public int BranchId { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
    }
}
