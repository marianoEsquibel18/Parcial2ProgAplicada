using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;
using System.Text.Json.Serialization;


namespace Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    public class UpdateAutomovilCommand : IRequest<bool>
    {
        [JsonIgnore]
        public int Id { get; set; }


        public string Marca {  get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Fabricacion { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        
    }
}
