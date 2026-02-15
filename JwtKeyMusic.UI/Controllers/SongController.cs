using JwtKeyMusic.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace JwtKeyMusic.UI.Controllers
{
    public class SongController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SongController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                TempData["ErrorMessage"] = "Lütfen önce giriş yapın.";
                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Discover()
        {
            var token = HttpContext.Session.GetString("token");
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://localhost:7180/api/Songs");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var songs = JsonSerializer.Deserialize<List<SongViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    ViewBag.Username = HttpContext.Session.GetString("username");
                    return View(songs ?? new List<SongViewModel>());
                }
                return View(new List<SongViewModel>());
            }
            catch { return View(new List<SongViewModel>()); }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AskAI([FromBody] AskAIRequest request)
        {
            try
            {
                var token = HttpContext.Session.GetString("token");
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Backend API'ye istek gönder
                var response = await client.GetAsync($"https://localhost:7180/api/Songs/AiSearch?prompt={Uri.EscapeDataString(request.Prompt)}");
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // API response'unu direkt dön
                    return Content(json, "application/json");
                }

                return Json(new { success = false, message = $"Backend hatası: {response.StatusCode}" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> CheckPackage([FromBody] CheckPackageRequest request)
        {
            try
            {
                var token = HttpContext.Session.GetString("token");
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Backend'den paket kontrolü yap
                var response = await client.GetAsync($"https://localhost:7180/api/Songs/{request.songId}/CanPlay");
                var json = await response.Content.ReadAsStringAsync();

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Paket kontrolü hatası: {ex.Message}" });
            }
        }
    }

    // Request Models
    public class CheckPackageRequest
    {
        public int songId { get; set; }
    }

    public class AskAIRequest
    {
        public string Prompt { get; set; } = "";
    }
}