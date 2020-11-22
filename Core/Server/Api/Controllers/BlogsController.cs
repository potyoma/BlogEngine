using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Data;
using BlogEngineApi.Models;
using Microsoft.AspNetCore.Mvc;
using BlogEngineApi.Utilities;

namespace BlogEngineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogService _data;

        public BlogsController(BlogService data)
        {
            _data = data;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> Get() =>
            await _data.GetAsync();

        [HttpGet("auth/{token}/{blogUrl}")]
        public async Task<ActionResult> Authorize(string token, string blogUrl)
        {
            var auth = await Authorizer.Authorize(token, blogUrl, _data);

            if (auth)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("{id:length(24)}", Name = "GetBlog")]
        public async Task<Blog> Get(string id) =>
            await _data.GetBlogAsync(id);

        [HttpPost]
        public async Task<ActionResult<Blog>> Create(Blog blog)
        {
            var created = await _data.CreateAsync(blog);

            return created;
        }

        [HttpPut("{token}")]
        public async Task<IActionResult> Update(
            string token, 
            [FromBody]Blog blogin)
        {
            var blog = await _data.Get(token);

            if (blog == null)
            {
                return NotFound();
            }

            await _data.UpdateAsync(token, blogin);

            return NoContent();
        }   

        [HttpDelete("{token}")]
        public async Task<IActionResult> Delete(string token)
        {
            var blog = await _data.Get(token);

            if (blog == null)
            {
                return NotFound();
            }

            await _data.RemoveAsync(blog.Token);

            return NoContent();
        }
    }
}