using Application.ApplicationServices;
using Application.UseCases.Automovil.Commands.CrearAutomovil;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
