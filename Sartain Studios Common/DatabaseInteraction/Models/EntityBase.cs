using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInteraction.Models
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("userid")]
        public string? UserId { get; set; }
    }
}