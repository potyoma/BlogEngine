using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Post
    {
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string PostName { get; set; }
        public string BlogUrl { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}