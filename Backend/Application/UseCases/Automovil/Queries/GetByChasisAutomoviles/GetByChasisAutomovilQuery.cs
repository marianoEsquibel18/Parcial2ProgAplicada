using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.UseCases.Automovil.Queries.GetByChasisAutomoviles
{
    public class GetByChasisAutomovilQuery : IRequest<Domain.Entities.Automovil>
    {
        public string NumeroChasis { get; set; }
    }
}
