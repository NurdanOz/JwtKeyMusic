using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<List<Song>> GetSongsByArtistAsync(int artistId);
        Task<List<Song>> GetSongsByGenreAsync(int genreId);
    }
}