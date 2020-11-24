using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;
using MongoDB.Driver;

namespace BlogEngineApi.Data
{
    public class PostService : Service, IPostService
    {
        private readonly IMongoCollection<Post> _posts;
        private readonly IMongoCollection<Blog> _blogs;

        public PostService(IDatabaseSettings settings)
            : base(settings)
        {
            _posts = Database.GetCollection<Post>(settings.PostsCollectionName);
            _blogs = Database.GetCollection<Blog>(settings.BlogsCollectionName);
        }
        
        public async Task<Post> Create(Post post)
        {
            await _posts.InsertOneAsync(post);
            return post;
        }

        public async Task Delete(string postId)
        {
            await _posts.DeleteOneAsync(p => p.Id == postId);
        }

        public async Task<List<Post>> GetAllByBlogAsync(string id)
        {
            var blog = await _blogs.Find(b => b.Id == id).FirstOrDefaultAsync();
            var blogUrl = blog.BlogUrl;
            return await _posts.Find(p => p.BlogUrl == blogUrl).ToListAsync();
        }

        public async Task<Post> GetPostAsync(string postId)
        {
            return await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task Update(string postId, Post postIn)
        {
            postIn.Id = postId;
            await _posts.ReplaceOneAsync(p => p.Id == postId, postIn);
        }
    }
}