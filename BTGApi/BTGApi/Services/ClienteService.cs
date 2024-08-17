using BTGApi.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BTGApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public ClienteService(IMongoDatabase database)
        {
            _clientes = database.GetCollection<Cliente>("Clientes");
        }

        public async Task<Cliente> GetClienteByIdAsync(string idCliente)
        {
            return await _clientes.Find(cliente => cliente.Id == idCliente).FirstOrDefaultAsync();
        }
    }
}
