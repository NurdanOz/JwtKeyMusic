using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface ISongService
    {
        Task<List<Song>> GetAllSongsAsync();
        Task<Song> GetSongByIdAsync(int id);
        Task<List<Song>> GetSongsByArtistAsync(int artistId);
        Task<List<Song>> GetSongsByGenreAsync(int genreId);
        Task CreateSongAsync(Song song);
        Task UpdateSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }
}