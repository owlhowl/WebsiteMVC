using System.Collections;
using WebsiteMVC.Models;

namespace WebsiteMVC.ViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable AllPosts { get; set; }
        public BlogListViewModel(ApplicationContext db)
        {
            AllPosts = db.BlogPosts;
        }
    }
}
