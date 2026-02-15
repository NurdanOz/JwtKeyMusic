using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;

namespace JwtKeyMusic.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Eğer token varsa zaten giriş yapmış demektir
            var token = HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Discover", "Song");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Username, string Password, bool RememberMe = false)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                TempData["ErrorMessage"] = "Kullanıcı adı ve şifre boş olamaz!";
                return View();
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var loginData = new
                {
                    username = Username,  // API'de küçük harf "username" bekliyor
                    password = Password
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(loginData),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://localhost:7180/api/Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<JsonElement>(json);

                    var token = responseObj.GetProperty("token").GetString();

                    // Session'a kaydet
                    HttpContext.Session.SetString("token", token ?? "");
                    HttpContext.Session.SetString("username", Username);

                    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);
                    var packageLevelClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "packageLevel");
                    if (packageLevelClaim != null)
                    {
                        HttpContext.Session.SetString("packageLevel", packageLevelClaim.Value);
                    }



                    // Remember Me için cookie süresi ayarla
                    if (RememberMe)
                    {
                        HttpContext.Session.SetString("RememberMe", "true");
                    }

                    TempData["SuccessMessage"] = "Giriş başarılı! Hoş geldiniz.";
                    return RedirectToAction("Discover", "Song");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent);
                        TempData["ErrorMessage"] = errorObj.GetProperty("message").GetString();
                    }
                    catch
                    {
                        TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı!";
                    }
                    return View();
                }
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "API'ye bağlanılamadı. Lütfen API'nin çalıştığından emin olun.";
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("Index", "Login");
        }
    }
}