using Application.ApplicationServices;
using Application.UseCases.Automovil.Commands.CrearAutomovil;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutomovilController : BaseController
    {
        private readonly AutomovilApplicationService _service;
        public AutomovilController (AutomovilApplicationService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult>
            CrearAutomovil([FromBody] CrearAutomovilCommand command)
        {
            var id = await _service.CrearAutomovil(command);
            return CreatedAtAction(nameof(CrearAutomovil), new { id }, id);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var automoviles = await _service.ObtenerTodosAutomoviles();
            return Ok(automoviles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var automovil = await _service.ObtenerAutomovilPorId(id);
            if(automovil == null)
            {
                return NotFound($"El autmovil Con {id} no fue encontrado");
            }
            return Ok(automovil);
        }
        [HttpGet("chasis/{numeroChasis}")]
        public async Task<IActionResult> GetByChasis(string numeroChasis)
        {
            var automovil = await _service.ObtenerAutomovilPorChasis(numeroChasis);

            if (automovil == null)
            {
                return NotFound($"El automovil con el chasis '{numeroChasis}' no se ha encontrado");
            }
            return Ok(automovil);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAutomovilCommand command)
        {
            command.Id = id;
            var resultado = await _service.ActualizarAutomovil(command);
            if (!resultado)
            {
                return NotFound($"El automovil con ID: '{id}' no ha sido encontrado");
            }
            return Ok("El automóvil ha sido actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.EliminarAutomovil(id);
            if (!resultado)
            {
                return NotFound($"El Automovil con el Id {id} no se ha encontrado");
            }
            return Ok("El Automovil ha sido eliminado correctamente");
        }

    }
}
