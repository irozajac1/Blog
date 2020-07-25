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
        public async Task<IActionResult> GetBlogPost(Guid id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _service.GetBlogPostById(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        // GET : api/posts
        [HttpGet]
        public async Task<IActionResult> GetRecent()
        {
            try
            {
                var response = await _service.GetRecentBlog();
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST : api/posts
        [HttpPost]
        public async Task<IActionResult> PostMethod([FromBody] BlogRequest blogRequest)
        {
            if(blogRequest ==  null || blogRequest.Title==null || blogRequest.Description==null || blogRequest.Body==null)
            {
                return BadRequest();
            }

            var response = await _service.SendBlogPost(blogRequest);
            return Ok(response);
        }

        //GET : api/posts/tagName
        [HttpGet("tagName")]
        public async Task<IActionResult> GetBlogsByTagName(string tagName)
        {
            if(tagName == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _service.GetBlogPostByTag(tagName);
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //PUT : api/posts/:5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(Guid id, [FromBody] BlogRequest blogRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid objeect sent from client");
                }
                var response = await _service.UpdateBlogPost(blogRequest, id);
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        // DELETE : api/posts/:5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            try
            {
                 _service.DeleteBlogPost(id);
                return Ok();
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}