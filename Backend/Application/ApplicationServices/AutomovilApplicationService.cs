using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.UseCases.Automovil.Commands;
using Application.UseCases.Automovil.Commands.CrearAutomovil;
using Application.UseCases.Automovil.Queries.GetAllAutomoviles;  
using Domain.Entities; 

namespace Application.ApplicationServices
{
    public class AutomovilApplicationService
    {
        private readonly IMediator _mediator;
        public AutomovilApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task <int>
            CrearAutomovil(CrearAutomovilCommand command)
            {
                return await _mediator.Send(command);
            }
        public async Task<IEnumerable<Automovil>> ObtenerTodosAutomoviles()
        {
            var query = new GetAllAutomovilQuery();
            return await _mediator.Send(query);
        }
    }
}
