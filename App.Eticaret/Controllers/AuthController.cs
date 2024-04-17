using App.Data.Contexts;
using App.Data.Entities;
using App.Eticaret.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register([FromForm] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Register form submitted with invalid data";
                return View();
            }

            var user = _dbContext.Users.SingleOrDefault(x => x.Email == registerViewModel.Email);

            if (user is not null)
            {
                ViewBag.Error = "User with this email is already exist";
                return View();
            }

            var newUser = new UserEntity
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                CreatedAt = DateTime.UtcNow,
                RoleId = 3
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            ViewBag.Success = "Register completed succesfully";
            return RedirectToAction("login", "Auth");
                                             
                                    
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromForm] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid login attempt";
                return View();
            }
            var user = _dbContext.Users.FirstOrDefault(x=>x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
            if (user == null)
            {
                ViewBag.Error = "Username or password is wrong";
                return View();
            }
            Response.Cookies.Append("user", $"{user.FirstName} {user.LastName}");
            return RedirectToAction("Index", "Home");
            
        }

        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword([FromForm] object forgotPasswordMailModel)
        {
            return View();
        }

        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword([FromRoute] string verificationCode)
        {
            return View();
        }

        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] object changePasswordModel)
        {
            return View();
        }

        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user");

            return RedirectToAction(nameof(Login));
        }
    }
}