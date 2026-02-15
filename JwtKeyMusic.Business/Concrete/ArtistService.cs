using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task<Artist> GetArtistWithSongsAsync(int id)
        {
            return await _unitOfWork.Artists.GetArtistWithSongsAsync(id);
        }

        public async Task CreateArtistAsync(Artist artist)
        {
            await _unitOfWork.Artists.AddAsync(artist);
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            await _unitOfWork.Artists.UpdateAsync(artist);
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _unitOfWork.Artists.GetByIdAsync(id);
            if (artist != null) await _unitOfWork.Artists.DeleteAsync(artist);
        }
    }
}