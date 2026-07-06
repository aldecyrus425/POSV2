using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.CreateBranch
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResponse>
    {
        private readonly IBranchRepository _branchrepository;
        public CreateBranchHandler(IBranchRepository repository)
        {
            _branchrepository = repository;
        }

        public async Task<CreateBranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = new Branches
                {
                    Name = request.BranchName,
                    Address = request.BranchAddress,
                    ContactNumber = request.BranchContactNumber,
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.UtcNow
                };

                await _branchrepository.CreateBranchAsync(branch);

                return new CreateBranchResponse
                {
                    isSuccess = true,
                    message = "Branch created successfully."
                };
            }
            catch (Exception ex)
            {
                return new CreateBranchResponse
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
