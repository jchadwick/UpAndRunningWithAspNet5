using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(long id)
        {
            ViewBag.Title = "My Blog Post";
            ViewBag.Posted = DateTime.Now;
            ViewBag.Author = "Jess Chadwick";
            ViewBag.Body = "My first blog post about ASP.NET MVC 6!";

            return View();
        }

        public int Echo(int id)
        {
            return id;
        }
    }
}
