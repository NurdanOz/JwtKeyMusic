using JwtKeyMusic.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JwtKeyMusic.UI.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArtistController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Her action'dan ÖNCE otomatik çalışır - token kontrolü
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

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("token");
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                // Sanatçıları çek
                var response = await client.GetAsync("https://localhost:7180/api/Artists");

                // Popüler şarkıları çek
                var popularResponse = await client.GetAsync("https://localhost:7180/api/Songs/popular");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var artists = JsonSerializer.Deserialize<List<ArtistViewModel>>(jsonString, options);

                    // Popüler şarkıları ViewBag'e ekle
                    if (popularResponse.IsSuccessStatusCode)
                    {
                        var popularJson = await popularResponse.Content.ReadAsStringAsync();
                        var popularSongs = JsonSerializer.Deserialize<List<PopularSongViewModel>>(popularJson, options);
                        ViewBag.PopularSongs = popularSongs;
                    }

                    ViewBag.Username = HttpContext.Session.GetString("username");
                    return View(artists ?? new List<ArtistViewModel>());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "Oturumunuz sona erdi. Lütfen tekrar giriş yapın.";
                    return RedirectToAction("Index", "Login");
                }

                ViewBag.Error = "Sanatçılar yüklenemedi.";
                return View(new List<ArtistViewModel>());
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Bir hata oluştu: {ex.Message}";
                return View(new List<ArtistViewModel>());
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var token = HttpContext.Session.GetString("token");
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7180/api/Artists/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var artistDetail = JsonSerializer.Deserialize<ArtistDetailViewModel>(jsonString, options);

                    ViewBag.Username = HttpContext.Session.GetString("username");
                    return View(artistDetail);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["ErrorMessage"] = "Sanatçı bulunamadı.";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "Oturumunuz sona erdi. Lütfen tekrar giriş yapın.";
                    return RedirectToAction("Index", "Login");
                }

                TempData["ErrorMessage"] = "Sanatçı detayı yüklenemedi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}