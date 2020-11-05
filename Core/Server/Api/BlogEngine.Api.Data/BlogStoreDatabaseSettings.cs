using System;

namespace BlogEngine.Api.Data
{
    public class BlogStoreDatabaseSettings : IBlogStoreDatabaseSettings
    {
        public string BlogsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
