using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models.Account;
using AspNetBlog.Models.Identity;

namespace AspNetBlog.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            var newUser = new ApplicationUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            // TODO: Add new user to the system
        }

    }
}
