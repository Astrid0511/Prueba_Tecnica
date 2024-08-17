using Microsoft.AspNetCore.Mvc;
using BTGApi.Models;
using BTGApi.Services;
using System.Collections.Generic;

namespace BTGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get() =>
            _productoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProducto")]
        public ActionResult<Producto> Get(string id)
        {
            var producto = _productoService.Get(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            _productoService.Create(producto);
            return CreatedAtRoute("GetProducto", new { id = producto._id.ToString() }, producto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Producto productoIn)
        {
            var producto = _productoService.Get(id);

            if (producto == null)
            {
                return NotFound();
            }

            _productoService.Update(id, productoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var producto = _productoService.Get(id);

            if (producto == null)
            {
                return NotFound();
            }

            _productoService.Remove(id);

            return NoContent();
        }
    }
}
