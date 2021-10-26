using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteMVC.Models;
using WebsiteMVC.ViewModels;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<IActionResult> AddPost(BlogPost post)
        {
            if (ModelState.IsValid)
            {
                post.Date = System.DateTime.Now;
                post.Title.Trim();
                post.Content.Trim();
                _db.BlogPosts.Add(post);
                _db.SaveChanges();
                return RedirectToAction("List", "Blog");
            }
            return View(post);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> EditPost(BlogPost newPost)
        {
            if (ModelState.IsValid)
            {
                var oldPost = _db.BlogPosts.Find(newPost.Id);
                newPost.Title.Trim();
                newPost.Content.Trim();
                oldPost.Title = newPost.Title;
                oldPost.Content = newPost.Content;
                _db.SaveChanges();
                return RedirectToAction("List", "Blog");
            }
            return View(newPost);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult EditPost(int id)
        {
            var post = _db.BlogPosts.Find(id);
            return View(post);
        }
        [Authorize(Roles = "admin")]
        public RedirectToActionResult DeletePost(int id)
        {
            var post = _db.BlogPosts.Find(id);
            _db.BlogPosts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("List", "Blog");
        }
        public ViewResult ViewPost(int id)
        {
            ViewBag.Posts = _db.BlogPosts;
            return View(_db.BlogPosts.Find(id));
        }
    }
}
