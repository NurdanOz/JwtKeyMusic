using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Playlist>> GetAllPlaylistsAsync()
        {
            return await _unitOfWork.Playlists.GetAllAsync();
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            return await _unitOfWork.Playlists.GetByIdAsync(id);
        }

        public async Task<List<Playlist>> GetPlaylistsByUserAsync(int userId)
        {
            return await _unitOfWork.Playlists.GetPlaylistsByUserAsync(userId);
        }

        public async Task CreatePlaylistAsync(Playlist playlist)
        {
            await _unitOfWork.Playlists.AddAsync(playlist);
        }

        public async Task UpdatePlaylistAsync(Playlist playlist)
        {
            await _unitOfWork.Playlists.UpdateAsync(playlist);
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _unitOfWork.Playlists.GetByIdAsync(id);
            if (playlist != null) await _unitOfWork.Playlists.DeleteAsync(playlist);
        }
    }
}