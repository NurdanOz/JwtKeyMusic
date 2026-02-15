using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<Artist> GetArtistWithSongsAsync(int artistId);
    }
}