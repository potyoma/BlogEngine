using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Data;
using BlogEngineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _data;

        public PostController(PostService data)
        {
            _data = data;
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<List<Post>>> GetByBlogAsync(string blogId)
        {
            return await _data.GetAllByBlogAsync(blogId);
        }
    }
}