using BTGApi.Models;
using BTGApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;

        public InscripcionesController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarInscripcion([FromBody] Inscripcion inscripcion)
        {
            var resultado = await _inscripcionService.RegistrarInscripcionAsync(inscripcion.IdProducto, inscripcion.Id);

            if (resultado.Contains("No tiene saldo disponible"))
            {
                return BadRequest(new { mensaje = resultado });
            }

            return Ok(new { mensaje = resultado });
        }
    }
}
