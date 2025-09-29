using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    public class DeleteAutomovilCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
