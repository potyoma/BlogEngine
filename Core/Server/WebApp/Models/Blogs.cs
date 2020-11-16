using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Blogs
    {
        public IEnumerable<Blog> AllBlogs { get; set; }

        public Blogs()
        {
            AllBlogs = GetBlogs().Result;
        }

        private static async Task<List<Blog>> GetBlogs()
        {
            using (var client = new HttpClient())
            {
                var request = await client
                    .GetAsync("https://blog-engine-api.herokuapp.com/api/blogs");
                var result = await request.Content.ReadFromJsonAsync<List<Blog>>();
                return result;
            }
        }
    }
}