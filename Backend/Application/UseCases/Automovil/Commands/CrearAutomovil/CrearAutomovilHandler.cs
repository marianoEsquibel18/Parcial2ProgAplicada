using Application.Repositories;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Commands.CrearAutomovil
{
    public class CrearAutomovilHandler : IRequestHandler<CrearAutomovilCommand, int>
    {
        private readonly IAutomovilRepository _repository;
        public CrearAutomovilHandler(IAutomovilRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> 
        Handle(CrearAutomovilCommand request, CancellationToken cancellationToken)
        {
            var automovil = new Domain.Entities.Automovil
            {
                Marca = request.Marca,
                Modelo = request.Modelo,
                Color = request.Color,
                Fabricacion = request.Fabricacion,
                NumeroMotor = request.NumeroMotor,
                NumeroChasis = request.NumeroChasis
            };
            await _repository.AddAsync(automovil);
            return automovil.Id;
        }
    }
}
