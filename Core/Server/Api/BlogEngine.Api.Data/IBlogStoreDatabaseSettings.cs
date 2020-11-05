namespace BlogEngine.Api.Data
{
    public interface IBlogStoreDatabaseSettings
    {
        string BlogCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}