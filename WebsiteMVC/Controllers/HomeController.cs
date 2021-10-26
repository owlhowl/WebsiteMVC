using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsiteMVC.Models;

namespace WebsiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}
