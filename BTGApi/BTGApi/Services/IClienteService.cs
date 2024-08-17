using BTGApi.Models;
using System.Threading.Tasks;

namespace BTGApi.Services
{
    public interface IClienteService
    {
        Task<Cliente> GetClienteByIdAsync(string idCliente);
    }
}
