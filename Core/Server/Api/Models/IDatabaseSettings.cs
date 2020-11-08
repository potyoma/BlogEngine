namespace BlogEngineApi.Models
{
    public interface IDatabaseSettings
    {
        string BlogsCollectionName { get; set; }
        string PostsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}