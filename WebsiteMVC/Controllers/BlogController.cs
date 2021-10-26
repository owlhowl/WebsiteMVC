using Microsoft.AspNetCore.Mvc;

namespace WebsiteMVC.Controllers
{
    public class BlogController : Controller
    {
        public ViewResult List()
        {
            return View();
        }
    }
}
