using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            var db = new BlogDataContext();
            db.Posts.Add(post);
            await db.SaveChangesAsync();

            return View();
        }

        public IActionResult Post(long id)
        {
            var post = new Post();

            post.Title = "My Blog Post";
            post.PostedDate = DateTime.Now;
            post.Author = "Jess Chadwick";
            post.Body = "This is my first blog post about ASP.NET MVC 6!";

            return View(post);
        }

    }
}
