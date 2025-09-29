using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.UseCases.Automovil.Commands;
using Application.UseCases.Automovil.Commands.CrearAutomovil;
using Application.UseCases.Automovil.Queries.GetAllAutomoviles;
using Application.UseCases.Automovil.Queries.GetByIdAutomoviles;
using Application.UseCases.Automovil.Queries.GetByChasisAutomoviles;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
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

        public async Task<Domain.Entities.Automovil> ObtenerAutomovilPorId(int id)
        {
            var query = new GetByIdAutomovilQuery { Id = id };
            return await _mediator.Send(query);
        }

        public async Task<Domain.Entities.Automovil> ObtenerAutomovilPorChasis(string numeroChasis)
        {
            var query = new GetByChasisAutomovilQuery
            {
                NumeroChasis = numeroChasis
            };
            return await _mediator.Send(query);
        }

        public async Task<bool> ActualizarAutomovil(UpdateAutomovilCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<bool> EliminarAutomovil(int id)
        {
            var command = new DeleteAutomovilCommand { Id = id };
            return await _mediator.Send(command);
        }
    }
}
