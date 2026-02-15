using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}