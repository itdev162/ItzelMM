using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }

    /// <summary>
    /// DELETE api/post/[id]
    /// </summary>
    /// <param name="id">Post id</param>
    /// <returns> True, if successful</returns>
    [HttpDelete("{id}")]

    public ActionResult<bool> Delete(Guid id)
    {
        var post = context,Posts.Find(id);

        if (post == null)
        {
            throw new Exception("Could not find post");
        }

        context.Remove(post);

        var success = context.SaveChanges() > 0;

        if (success)
        {
            return true;
        }

        throw new Exception("Error deleting post");
    }
}