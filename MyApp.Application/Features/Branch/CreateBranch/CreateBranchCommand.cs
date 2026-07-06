using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.CreateBranch
{
    public class CreateBranchCommand : IRequest<CreateBranchResponse>
    {
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchContactNumber { get; set; }
        public bool IsActive { get; set; }

    }
}
