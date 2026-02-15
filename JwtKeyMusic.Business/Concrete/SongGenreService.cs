using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class SongGenreService : ISongGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongGenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SongGenre>> GetAllSongGenresAsync()
        {
            return await _unitOfWork.SongGenres.GetAllAsync();
        }

        public async Task CreateSongGenreAsync(SongGenre songGenre)
        {
            await _unitOfWork.SongGenres.AddAsync(songGenre);
        }

        public async Task DeleteSongGenreAsync(int songId, int genreId)
        {
            var songGenre = await _unitOfWork.SongGenres.GetByIdAsync(songId);
            if (songGenre != null) await _unitOfWork.SongGenres.DeleteAsync(songGenre);
        }
    }
}