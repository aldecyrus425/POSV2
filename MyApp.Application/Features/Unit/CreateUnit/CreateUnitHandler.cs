using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Unit.CreateUnit
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, CreateUnitResponse>
    {
        private readonly IUnitRepository _unitRepository;

        public CreateUnitHandler(IUnitRepository unitRepository )
        {
            _unitRepository = unitRepository;
        }

        public async Task<CreateUnitResponse> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unit = new Units
                {
                    UnitName = request.UnitName,
                    Symbol = request.UnitSymbol
                };

                await _unitRepository.CreateUnitAsync(unit);

                return new CreateUnitResponse
                {
                    isSuccess = true,
                    message = "Unit created successfully."
                };
            }
            catch (Exception ex)
            {
                return new CreateUnitResponse
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
