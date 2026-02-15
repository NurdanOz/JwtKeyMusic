using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}