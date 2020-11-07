namespace BlogEngineApi.Models
{
    public class PostsDatabaseSettings 
    {
        public string PostsCollectionName
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