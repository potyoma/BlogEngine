using BlogEngine.Api.Core;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Api.Data
{
    public class BlogService
    {
        private readonly IMongoCollection<Blog> _blogs;

        public BlogService(IBlogStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _blogs = database.GetCollection<Blog>(settings.BlogCollectionName);
        }

        public List<Blog> Get() => 
            _blogs.Find(b => true).ToList();

        public Blog Get(string id) =>
            _blogs.Find<Blog>(b => b.Id == id).FirstOrDefault();

        public Blog Create(Blog blog)
        {
            _blogs.InsertOne(blog);
            return blog;
        }

        public void Update(string id, Blog blogIn) =>
            _blogs.ReplaceOne(b => b.Id == id, blogIn);

        public void Remove(Blog blogIn) =>
            _blogs.DeleteOne(b => b.Id == blogIn.Id);
        
        public void Remove(string id) =>
            _blogs.DeleteOne(b => b.Id == id);
    }
}