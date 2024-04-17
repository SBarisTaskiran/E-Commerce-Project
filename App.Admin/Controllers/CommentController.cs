using App.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("/comment")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpGet]
        public IActionResult Approve([FromRoute] int commentId)
        {
            return RedirectToAction(nameof(List));
        }
    }
}