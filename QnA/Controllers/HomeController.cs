using DataAccessLayer.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QnA.Models;

using System.Diagnostics;

namespace QnA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
       
            _logger = logger;
           
        }

        public IActionResult Index()
        {

            return View();
        }


       
    }
}
