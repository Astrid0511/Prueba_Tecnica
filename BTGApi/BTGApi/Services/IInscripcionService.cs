using BTGApi.Models;

namespace BTGApi.Services
{
    public interface IInscripcionService
    {
        Task<string> RegistrarInscripcionAsync(int idProducto, string idCliente);
    }
}
