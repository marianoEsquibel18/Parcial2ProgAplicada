using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Automovil.Queries.GetByIdAutomoviles
{
    public class GetByIdAutomovilQuery : IRequest<Domain.Entities.Automovil>
    {
        public int Id { get; set; }
    }
}
