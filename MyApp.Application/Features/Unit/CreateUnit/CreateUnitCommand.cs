using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Unit.CreateUnit
{
    public class CreateUnitCommand : IRequest<CreateUnitResponse>
    {
        public string UnitName { get; set; }
        public string UnitSymbol { get; set; }
    }
}
