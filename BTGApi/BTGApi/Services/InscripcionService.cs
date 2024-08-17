using BTGApi.Models;
using MongoDB.Driver;

namespace BTGApi.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly IMongoCollection<Inscripcion> _inscripciones;
        private readonly IProductoService _productoService;
        private readonly IClienteService _clienteService;

        public InscripcionService(IMongoDatabase database, IProductoService productoService, IClienteService clienteService)
        {
            _inscripciones = database.GetCollection<Inscripcion>("Inscripciones");
            _productoService = productoService;
            _clienteService = clienteService;
        }

        public async Task<string> RegistrarInscripcionAsync(int idProducto, string idCliente)
        {
            var producto = await _productoService.GetProductoByIdAsync(idProducto);
            var cliente = await _clienteService.GetClienteByIdAsync(idCliente);

            if (cliente == null || producto == null)
            {
                return "Producto o Cliente no encontrados.";
            }

            if (Convert.ToDecimal(cliente.SaldoDisponible) < Convert.ToDecimal(producto.MontoMinVin))
            {
                return $"No tiene saldo disponible para vincularse al fondo {producto.Nombre}.";
            }

            var inscripcion = new Inscripcion
            {
                IdProducto = idProducto,
                IdCliente = Convert.ToByte(idCliente) 
            };

            await _inscripciones.InsertOneAsync(inscripcion);
            return "Inscripción registrada exitosamente.";
        }
    }
}
