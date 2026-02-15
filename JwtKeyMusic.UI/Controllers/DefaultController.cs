using Microsoft.AspNetCore.Mvc;
namespace JwtKeyMusic.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}