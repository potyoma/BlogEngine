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
        
        public Task Create(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string postId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Post>> GetAllByBlogAsync(string blogId)
        {
            return await _posts.Find(p => p.BlogId == blogId).ToListAsync();
        }

        public Task<Post> GetPostAsync(string postId)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(string postId, Post postIn)
        {
            throw new System.NotImplementedException();
        }
    }
}