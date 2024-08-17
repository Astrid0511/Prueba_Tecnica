using MongoDB.Driver;
using BTGApi.Models;
using System.Collections.Generic;

namespace BTGApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IMongoCollection<Producto> _productos;

        public ProductoService(IMongoDatabase db)
        {
            _productos = db.GetCollection<Producto>("Producto");
        }

        public List<Producto> Get() =>
            _productos.Find(producto => true).ToList();

        public Producto Get(string id) =>
            _productos.Find<Producto>(producto => producto._id == id).FirstOrDefault();

        public Producto Create(Producto producto)
        {
            _productos.InsertOne(producto);
            return producto;
        }

        public void Update(string id, Producto producto) =>
            _productos.ReplaceOne(producto => producto._id == id, producto);

        public void Remove(string id) =>
            _productos.DeleteOne(producto => producto._id == id);

        public Task<Producto> GetProductoByIdAsync(int idProducto)
        {
            throw new NotImplementedException();
        }
    }
}
