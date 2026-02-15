using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}