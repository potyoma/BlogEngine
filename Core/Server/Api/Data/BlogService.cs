using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;
using BlogEngineApi.Utilities;
using System.Linq;
using MongoDB.Driver;

namespace BlogEngineApi.Data
{
    public class BlogService : Service, IBLogService
    {
        private readonly IMongoCollection<Blog> _blogs;

        public BlogService(IDatabaseSettings settings)
            : base(settings)
        {
            _blogs = Database.GetCollection<Blog>(settings.BlogsCollectionName);
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            blog.Token = Tokenizer.Create(blog.BlogUrl, blog.Email).Result;
            await _blogs.InsertOneAsync(blog);
            return blog;
        }

        public async Task<List<Blog>> GetAsync()
        {
            var blogs = await _blogs
                .Find(b => true)
                .ToListAsync();

            return blogs
                .Select(b => new Blog
                {
                    Id = b.Id,
                    BlogName = b.BlogName,
                    BlogUrl = b.BlogUrl,
                    Author = b.Author,
                    Category = b.Category
                })
                .ToList();
        }

        public async Task<Blog> Get(string token)
        {
            return await _blogs.Find(b => b.Token == token).FirstOrDefaultAsync();
        }

        public async Task<Blog> GetBlogAsync(string id)
        {
            var blog = await _blogs
                .Find(b => b.Id == id)
                .FirstOrDefaultAsync();
            
            blog.Token = null;
            blog.Email = null;

            return blog;
        }

        public async Task RemoveAsync(string token)
        {
            await _blogs.DeleteOneAsync(b => b.Token == token);
        }

        public async Task UpdateAsync(string token, Blog blogin)
        {
            var blog = await _blogs.Find(b => b.Token == token).FirstOrDefaultAsync();
            blogin.Id = blog.Id;
            blogin.Token = token;
            await _blogs.ReplaceOneAsync(b => b.Token == token, blogin);
        }
    }
}