using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _unitOfWork.Genres.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _unitOfWork.Genres.GetByIdAsync(id);
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            await _unitOfWork.Genres.AddAsync(genre);
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            if (genre != null) await _unitOfWork.Genres.DeleteAsync(genre);
        }
    }
}