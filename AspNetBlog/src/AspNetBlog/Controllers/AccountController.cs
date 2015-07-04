using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models.Account;
using AspNetBlog.Models.Identity;
using Microsoft.AspNet.Identity;

namespace AspNetBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(
                login.EmailAddress,
                login.Password,
                login.RememberMe,
                false);

            if (!result.Succeeded)
            {
                return View(login);
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult Logout(string returnUrl = null)
        {
            _signInManager.SignOut();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }



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

            var result = await _userManager.CreateAsync(newUser, registration.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Error creating user");
                return View(registration);
            }

            return RedirectToAction("Login");
        }

    }
}
