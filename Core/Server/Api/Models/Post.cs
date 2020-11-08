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

        [BsonElement("blogId")]
        public string BlogId { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
    }
}