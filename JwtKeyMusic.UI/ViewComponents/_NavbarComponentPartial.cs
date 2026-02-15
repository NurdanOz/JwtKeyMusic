using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}