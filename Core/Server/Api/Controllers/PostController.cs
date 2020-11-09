using System;
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
        private readonly BlogService _blogs;

        public PostController(PostService data, BlogService blogs)
        {
            _data = data;
            _blogs = blogs;
        }

        [HttpGet("{blog}")]
        public async Task<ActionResult<List<Post>>> GetByBlogAsync(string blogId)
        {
            return await _data.GetAllByBlogAsync(blogId);
        }

        [HttpGet("get/{postId}")]
        public async Task<ActionResult<Post>> GetPost(string postId)
        {
            return await _data.GetPostAsync(postId);
        }

        [HttpDelete("{token}/{postId}")]
        public async Task<IActionResult> Delete(string token, string postId)
        {
            var post = await _data.GetPostAsync(postId);
            if (post == null)
            {
                return NotFound();
            }

            var auth = await Authorize(token, post.BlogId);
            if (!auth)
            {
                return BadRequest();
            }

            await _data.Delete(postId);
            return NoContent();
        }

        [HttpPut("{token}/{postId}")]
        public async Task<IActionResult> Update(
            string token, 
            string postId,
            [FromBody]Post postIn)
        {
            var post = await _data.GetPostAsync(postId);
            if (post == null)
            {
                return NotFound();
            }

            var auth = await Authorize(token, post.BlogId);
            if (!auth)
            {
                return BadRequest();
            }

            await _data.Update(postId, postIn);
            return NoContent();
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> CreatePost(
            string token, [FromBody]Post post)
        {   
            // Contains authorization condition.
            var auth = await Authorize(token, post.BlogId);

            if (!auth)
            {
                return BadRequest();
            }

            await _data.Create(post);
            return NoContent();
        }

        private async Task<bool> Authorize(string token, string blogId)
        {
            var blog = await _blogs.GetBlogAsync(blogId);
            
            return blog.Token == token;
        }
    }
}