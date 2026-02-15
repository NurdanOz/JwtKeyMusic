using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DTO.Dto;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace JwtKeyMusic.Business.Concrete
{
    public class GeminiService : IGeminiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl;
        public GeminiService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["Gemini:ApiKey"] ?? "";
            _apiUrl = configuration["Gemini:ApiUrl"] ?? "";
        }
        public async Task<GeminiResponseDto> AnalyzePromptAsync(string userPrompt)
        {
            try
            {
                // Prompt metni
                string promptText = "Sen bir müzik asistanısın. Kullanıcının talebini analiz et ve müzik türlerini belirle.\n" +
                    "Mevcut türler: Pop, Rock, Rap, Arabesk, Alternatif, Elektronik\n" +
                    "Kullanıcı mesajı: " + userPrompt + "\n" +
                    "Sadece şu JSON formatında cevap ver. Mood'u kullanıcının talebine göre belirle (Enerjik, Sakin, Melankolik, Neşeli, Hüzünlü, Keder):\n" +
                    "{\"genres\": [\"Pop\", \"Rock\"], \"mood\": \"enerjik\"}\n" +
                    "ÖNEMLİ: Sadece JSON cevap ver, başka açıklama yazma!";

                // İstek body'sini oluştur
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new
                                {
                                    text = promptText
                                }
                            }
                        }
                    }
                };

                // HTTP isteğini gönder
                var content = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.PostAsync(
                    $"{_apiUrl}?key={_apiKey}",
                    content
                );

                // Başarısız response kontrolü
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"GEMINI API ERROR: {response.StatusCode} - {errorContent}");
                    return new GeminiResponseDto();
                }

                // JSON response'u parse et
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var geminiResult = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                // Gemini'nin döndürdüğü metin kısmını çıkar
                var textResponse = geminiResult
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                // JSON'dan markdown formatını temizle
                textResponse = textResponse?.Replace("```json", "").Replace("```", "").Trim();

                // JSON string'i GeminiResponseDto'ya deserialize et
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<GeminiResponseDto>(textResponse, options);

                return result ?? new GeminiResponseDto();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GEMINI EXCEPTION: {ex.Message}");
                return new GeminiResponseDto();
            }
        }
    }
}