namespace BlogEngineApi.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BlogsCollectionName { get; set; }
        public string PostsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}