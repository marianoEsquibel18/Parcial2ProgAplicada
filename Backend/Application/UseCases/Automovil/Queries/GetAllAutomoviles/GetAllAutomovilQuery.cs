using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
    public class GetAllAutomovilQuery : IRequest<IEnumerable<Domain.Entities.Automovil>>
    {
    }
}