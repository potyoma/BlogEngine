namespace BlogEngineApi.Models
{
    public class BlogDatabaseSettings : IDatabaseSettings
    {   
        public string BlogsCollectionName
        {
            get
            {
                return CollectionName;
            }
            set
            {
                CollectionName = value;
            }
        }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}