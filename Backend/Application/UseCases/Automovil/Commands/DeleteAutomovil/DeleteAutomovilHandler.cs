using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Application.Repositories;
using MediatR;


namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    public class DeleteAutomovilHandler : IRequestHandler<DeleteAutomovilCommand, bool>
    {
        private readonly IAutomovilRepository _repository;

        public DeleteAutomovilHandler(IAutomovilRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAutomovilCommand request, CancellationToken cancellationToken)
        {
            var automovil = await _repository.GetByIdAsync(request.Id);

            if (automovil == null)
            {
                return false; 
            }

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
