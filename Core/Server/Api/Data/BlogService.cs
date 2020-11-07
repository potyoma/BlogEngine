using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;
using MongoDB.Driver;

namespace BlogEngineApi.Data
{
    public class BlogService
    {
        private readonly IMongoCollection<Blog> _blogs;

        public BlogService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _blogs = database.GetCollection<Blog>(settings.BlogsCollectionName);
        }

        public async Task<List<Blog>> GetAsync() => 
            await _blogs.Find(b => true).ToListAsync();
    }
}