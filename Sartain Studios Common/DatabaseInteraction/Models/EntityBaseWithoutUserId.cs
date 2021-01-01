using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInteraction.Models
{
    public abstract class EntityBaseWithoutUserId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}