using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteMVC.Models;
using WebsiteMVC.ViewModels;
using System.Threading.Tasks;

namespace WebsiteMVC.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationContext _db;
        public BlogController(ApplicationContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ViewResult List()
        {
            return View(new BlogListViewModel(_db));
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(BlogPost post)
        {
            post.Date = System.DateTime.Now;
            _db.BlogPosts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("ViewPost", "Blog", post);
        }
        public ViewResult ViewPost(int id)
        {
            ViewBag.Posts = _db.BlogPosts;
            return View(_db.BlogPosts.Find(id));
        }
    }
}
