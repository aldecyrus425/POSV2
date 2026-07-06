using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.CreateBranch
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator() 
        {
            RuleFor(x => x.BranchName).NotEmpty();
            RuleFor(x => x.BranchAddress).NotEmpty();
            RuleFor(x => x.BranchContactNumber).NotEmpty();
            RuleFor(x => x.IsActive).NotNull();
        }
    }
}
