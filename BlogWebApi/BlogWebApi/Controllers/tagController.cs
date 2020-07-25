using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Interface;
using BlogWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IBlogService _service;

        public TagController(IBlogService service)
        {
            _service = service;
        }

        //GET : api/tags
        [HttpGet]
        public ActionResult<List<Tag>>GetTagList()
        {
            return _service.TagsList();
        }
    }
}