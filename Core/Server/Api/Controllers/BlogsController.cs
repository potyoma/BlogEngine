using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngineApi.Data;
using BlogEngineApi.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}