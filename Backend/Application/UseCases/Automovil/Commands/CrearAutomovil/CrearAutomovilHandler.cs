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
        public async Task<int> Handle(CrearAutomovilCommand request, CancellationToken cancellationToken)
        {

            var existeMotor = await _repository.GetByMotorAsync(request.NumeroMotor);
            if (existeMotor != null)
            {
                throw new InvalidOperationException($"Ya existe un automóvil con el número de motor: {request.NumeroMotor}");
            }

            var existeChasis = await _repository.GetByChasisAsync(request.NumeroChasis);
            if (existeChasis != null)
            {
                throw new InvalidOperationException($"Ya existe un automóvil con el número de chasis: {request.NumeroChasis}");
            }
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
