using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetByChasisAutomoviles
{
    public class GetByChasisAutomovilHandler : IRequestHandler<GetByChasisAutomovilQuery, Domain.Entities.Automovil>
    {
        private readonly IAutomovilRepository _repository;

        public GetByChasisAutomovilHandler(IAutomovilRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Automovil> Handle(GetByChasisAutomovilQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByChasisAsync(request.NumeroChasis);
        }
    }
}
