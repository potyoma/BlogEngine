using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Models;

namespace BlogEngineApi.Data
{
    public interface IBLogService
    {
        Task<List<Blog>> GetAsync();
        Task<Blog> GetBlogAsync(string id);
        Task<Blog> CreateAsync(Blog blog);
        Task UpdateAsync(string token, Blog blogin);
        Task RemoveAsync(string token);
    }
}