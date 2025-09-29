using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Application.Repositories;
using Domain.Entities;

namespace Application.UseCases.Automovil.Queries.GetByIdAutomoviles
{
    public class GetByIdAutomovilHandler : IRequestHandler<GetByIdAutomovilQuery, Domain.Entities.Automovil>
    {
        private readonly IAutomovilRepository _repository;

        public GetByIdAutomovilHandler(IAutomovilRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Entities.Automovil> Handle(GetByIdAutomovilQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
