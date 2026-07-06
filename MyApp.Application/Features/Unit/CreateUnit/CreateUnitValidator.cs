using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Unit.CreateUnit
{
    public class CreateUnitValidator : AbstractValidator<CreateUnitCommand>
    {
        public CreateUnitValidator()
        {
            RuleFor(x => x.UnitName).NotEmpty();
            RuleFor(x => x.UnitSymbol).NotEmpty();
        }
    }
}
