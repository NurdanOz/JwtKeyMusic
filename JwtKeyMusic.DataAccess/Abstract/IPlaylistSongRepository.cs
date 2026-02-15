using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IPlaylistSongRepository : IGenericRepository<PlaylistSong>
    {
        Task<List<PlaylistSong>> GetSongsByPlaylistAsync(int playlistId);
    }
}