using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BTGApi.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("MontoMinVin")]
        public string MontoMinVin { get; set; }

        [BsonElement("tipoProducto")]
        public string TipoProducto { get; set; }
    }
}
