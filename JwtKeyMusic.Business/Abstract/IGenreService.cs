using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task CreateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
    }
}