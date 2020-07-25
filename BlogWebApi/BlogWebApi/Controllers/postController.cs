using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using BlogWebApi.Interface;
using BlogWebApi.Models;
using BlogWebApi.Models.Request;
using BlogWebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IBlogService _service;

        public PostController(IBlogService service)
        {
            _service = service;
        }

        // GET : api/posts/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(Guid id)
        {
            return _service.GetBlogPotBySlug(id);
        }

        // GET : api/posts
        [HttpGet]
        public ActionResult<BlogPost> GetRecent()
        {
            return _service.GetRecentBlog();
        }

        // POST : api/posts
        [HttpPost]
        public ActionResult<BlogPost> PostMethod([FromBody] BlogRequest blogRequest)
        {
            return _service.SendBlogPost(blogRequest);
        }

        //GET : api/posts/tagName
        [HttpGet("tagName")]
        public ActionResult<MultipleBlogsResponse>GetBlogsByTagName(string tagName)
        {
            return _service.GetBlogPostByTag(tagName);
        }

        //PUT : api/posts/:5
        [HttpPut("{id}")]
        public ActionResult<BlogPost> UpdateBlog(Guid id, [FromBody] BlogRequest blogRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid objeect sent from client");
                }
                _service.UpdateBlogPost(blogRequest, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        // DELETE : api/posts/:5
        [HttpDelete("{id}")]
        public ActionResult DeleteBlogPost(Guid id)
        {
            _service.DeleteBlogPost(id);
            return Ok();
        }
    }
}