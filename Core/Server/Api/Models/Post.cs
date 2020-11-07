using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogEngineApi.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string PostName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string BlogId { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}