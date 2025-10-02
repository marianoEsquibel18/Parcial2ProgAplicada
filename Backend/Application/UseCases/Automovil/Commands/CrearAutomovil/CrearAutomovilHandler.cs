using Application.Repositories;
using MediatR;
using Domain.Entities;
using System;
using System.Threading;
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
            var numeroMotor = GenerarNumeroMotor();
            var numeroChasis = GenerarNumeroChasis();
            var fabricacion = 2025; 

            while (await _repository.GetByMotorAsync(numeroMotor) != null)
            {
                numeroMotor = GenerarNumeroMotor(); 
            }

            while (await _repository.GetByChasisAsync(numeroChasis) != null)
            {
                numeroChasis = GenerarNumeroChasis(); 
            }

            var automovil = new Domain.Entities.Automovil
            {
                Marca = request.Marca,
                Modelo = request.Modelo,
                Color = request.Color,
                Fabricacion = fabricacion,        
                NumeroMotor = numeroMotor,        
                NumeroChasis = numeroChasis       
            };

            await _repository.AddAsync(automovil);
            return automovil.Id;
        }

        private string GenerarNumeroMotor()
        {
            return $"MOT-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }

        private string GenerarNumeroChasis()
        {
            return $"CHS-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }
    }
}