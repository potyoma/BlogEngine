using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;

namespace BlogEngineApi.Data
{
    public interface IPostService
    {
        Task<List<Post>> GetAllByBlogAsync(string blogId);
        Task<Post> GetPostAsync(string postId);
        Task Delete(string postId);
        Task Update(string postId, Post postIn);
        Task<Post> Create(Post post);
    }
}