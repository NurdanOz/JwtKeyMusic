using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IArtistService
    {
        Task<List<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task<Artist> GetArtistWithSongsAsync(int id);
        Task CreateArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        Task DeleteArtistAsync(int id);
    }
}