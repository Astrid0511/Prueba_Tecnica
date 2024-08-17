using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BTGApi.Models
{
    public class Inscripcion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("idProducto")]
        public int IdProducto { get; set; }

        [BsonElement("idCliente")]
        public int IdCliente { get; set; }
    }
}
