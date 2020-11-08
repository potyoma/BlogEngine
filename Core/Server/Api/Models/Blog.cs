using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogEngineApi.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string BlogName { get; set; }
        [BsonElement("blogId")]
        public string BlogId { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("token")]
        public string Token { get; set; }
    }
}