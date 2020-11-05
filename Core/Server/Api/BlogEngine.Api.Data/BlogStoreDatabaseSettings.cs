using System;

namespace BlogEngine.Api.Data
{
    public class BlogStoreDatabaseSettings : IBlogStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BlogCollectionName { get; set; }
    }
}
