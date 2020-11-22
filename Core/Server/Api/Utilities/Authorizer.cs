using BlogEngineApi.Data;
using System.Threading.Tasks;

namespace BlogEngineApi.Utilities
{
    public static class Authorizer
    {
        public static async Task<bool> Authorize(string token, string blogUrl, BlogService blogs)
        {
            var blog = await blogs.Get(token);

            if (blog == null)
            {
                return false;
            }
            
            return blog.BlogUrl == blogUrl;
        }
    }
}