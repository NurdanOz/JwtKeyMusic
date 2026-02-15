using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IPlaylistSongService
    {
        Task<List<PlaylistSong>> GetAllPlaylistSongsAsync();
        Task<List<PlaylistSong>> GetSongsByPlaylistAsync(int playlistId);
        Task CreatePlaylistSongAsync(PlaylistSong playlistSong);
        Task DeletePlaylistSongAsync(int playlistId, int songId);
    }
}