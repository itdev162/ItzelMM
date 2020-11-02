using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Posts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator) => this.mediator = mediator;

        public ActionResult<List<Post>> List()
        {
            return this.mediator.Send(new List.Query());
        }

        [HttpGet]

        public ActionResult<List<Post>> Get() 
        {
            return this.context.Posts.ToList();
        }

        /// <summary>
        /// GET api/post/[id]
        /// <summary>
        /// <param name="id">Post id</param>
        /// <returns>A single post</returns>
        [HttpGet("{id}")] 

        public ActionResult<Post> GetById(Guid id)
        {
            return this.context.Posts.Find(id);
        }
    }
}