using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using smart_family_backend.Contracts.V1;
using smart_family_backend.Domain;

namespace smart_family_backend.Controllers.V1
{

    public class PostsController : Controller
    {
        private List<Post> _posts;
        public PostsController()
        {
            _posts = new List<Post>();
            for(var i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}
