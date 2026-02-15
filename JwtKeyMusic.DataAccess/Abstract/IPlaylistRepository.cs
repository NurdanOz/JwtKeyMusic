using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<List<Playlist>> GetPlaylistsByUserAsync(int userId);
    }
}