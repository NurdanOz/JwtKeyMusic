using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface ISongGenreService
    {
        Task<List<SongGenre>> GetAllSongGenresAsync();
        Task CreateSongGenreAsync(SongGenre songGenre);
        Task DeleteSongGenreAsync(int songId, int genreId);
    }
}