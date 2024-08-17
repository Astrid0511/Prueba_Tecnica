using BTGApi.Models;
using System.Collections.Generic;

namespace BTGApi.Services
{
    public interface IProductoService
    {
        Task<Producto> GetProductoByIdAsync(int idProducto);
        List<Producto> Get();
        Producto Get(string id);
        Producto Create(Producto producto);
        void Update(string id, Producto producto);
        void Remove(string id);
    }
}
