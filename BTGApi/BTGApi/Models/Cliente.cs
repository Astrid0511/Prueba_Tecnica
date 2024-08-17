using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BTGApi.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string Id { get; set; } = null!;

        [BsonElement("nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("apellidos")]
        public string Apellidos { get; set; } = null!;

        [BsonElement("ciudad")]
        public string Ciudad { get; set; } = null!;
        [BsonElement("SaldoDisponible")]
        public string SaldoDisponible { get; set; } = null!;
    }
}
