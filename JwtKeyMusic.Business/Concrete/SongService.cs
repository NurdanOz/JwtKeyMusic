using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Song>> GetAllSongsAsync() => await _unitOfWork.Songs.GetAllAsync();
        public async Task<Song> GetSongByIdAsync(int id) => await _unitOfWork.Songs.GetByIdAsync(id);
        public async Task<List<Song>> GetSongsByArtistAsync(int artistId) => await _unitOfWork.Songs.GetSongsByArtistAsync(artistId);
        public async Task<List<Song>> GetSongsByGenreAsync(int genreId) => await _unitOfWork.Songs.GetSongsByGenreAsync(genreId);
        public async Task CreateSongAsync(Song song) => await _unitOfWork.Songs.AddAsync(song);
        public async Task UpdateSongAsync(Song song) => await _unitOfWork.Songs.UpdateAsync(song);
        public async Task DeleteSongAsync(int id)
        {
            var song = await _unitOfWork.Songs.GetByIdAsync(id);
            if (song != null) await _unitOfWork.Songs.DeleteAsync(song);
        }
    }
}