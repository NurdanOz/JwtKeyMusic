using JwtKeyMusic.DTO.Dto;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IGeminiService
    {
        Task<GeminiResponseDto> AnalyzePromptAsync(string userPrompt);
    }
}