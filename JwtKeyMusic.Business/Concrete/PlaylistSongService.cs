using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistSongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PlaylistSong>> GetAllPlaylistSongsAsync()
        {
            return await _unitOfWork.PlaylistSongs.GetAllAsync();
        }

        public async Task<List<PlaylistSong>> GetSongsByPlaylistAsync(int playlistId)
        {
            return await _unitOfWork.PlaylistSongs.GetSongsByPlaylistAsync(playlistId);
        }

        public async Task CreatePlaylistSongAsync(PlaylistSong playlistSong)
        {
            await _unitOfWork.PlaylistSongs.AddAsync(playlistSong);
        }

        public async Task DeletePlaylistSongAsync(int playlistId, int songId)
        {
            var playlistSong = await _unitOfWork.PlaylistSongs.GetByIdAsync(playlistId);
            if (playlistSong != null) await _unitOfWork.PlaylistSongs.DeleteAsync(playlistSong);
        }
    }
}