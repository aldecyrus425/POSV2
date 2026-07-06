using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Contact_Num).NotEmpty();
            RuleFor(x => x.BranchId).GreaterThan(0);
            RuleFor(x => x.RoleId).GreaterThan(0);
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
