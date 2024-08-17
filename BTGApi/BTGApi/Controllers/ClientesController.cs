using BTGApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;

namespace BTGApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClientesController(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Cliente");
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get() =>
            await _clientesCollection.Find(_ => true).ToListAsync();

        [HttpGet("{id:length(24)}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> Get(string id)
        {
            var cliente = await _clientesCollection.Find<Cliente>(c => c.Id == id).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clientesCollection.InsertOneAsync(cliente);
            return CreatedAtRoute("GetCliente", new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cliente clienteIn)
        {
            var cliente = await _clientesCollection.Find<Cliente>(c => c.Id == id).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            await _clientesCollection.ReplaceOneAsync(c => c.Id == id, clienteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clientesCollection.Find<Cliente>(c => c.Id == id).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            await _clientesCollection.DeleteOneAsync(c => c.Id == id);

            return NoContent();
        }
    }
}
