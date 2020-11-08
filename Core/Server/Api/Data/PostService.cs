using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;
using MongoDB.Driver;

namespace BlogEngineApi.Data
{
    public class PostService : Service, IPostService
    {
        private readonly IMongoCollection<Post> _posts;

        public PostService(IDatabaseSettings settings)
            : base(settings)
        {
            _posts = Database.GetCollection<Post>(settings.PostsCollectionName);
        }
        
        public async Task Create(Post post)
        {
            await _posts.InsertOneAsync(post);
        }

        public async Task Delete(string postId)
        {
            await _posts.DeleteOneAsync(p => p.Id == postId);
        }

        public async Task<List<Post>> GetAllByBlogAsync(string blogId)
        {
            return await _posts.Find(p => p.BlogId == blogId).ToListAsync();
        }

        public async Task<Post> GetPostAsync(string postId)
        {
            return await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task Update(string postId, Post postIn)
        {
            await _posts.ReplaceOneAsync(p => p.Id == postId, postIn);
        }
    }
}