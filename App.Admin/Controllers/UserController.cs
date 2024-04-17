using App.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("/users")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/users/{userId:int}/approve")]
        [HttpGet]
        public IActionResult Approve([FromRoute] int userId)
        {
            return View();
        }
    }
}