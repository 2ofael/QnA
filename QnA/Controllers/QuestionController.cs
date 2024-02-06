using Microsoft.AspNetCore.Mvc;

namespace QnA.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
