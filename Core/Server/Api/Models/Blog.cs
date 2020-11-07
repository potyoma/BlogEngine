using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogEngineApi.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BlogName { get; set; }
        public string BlogId { get; set; }
        public string Email { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Token { get; set; }
    }
}