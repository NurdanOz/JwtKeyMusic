using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        private readonly AppDbContext _context;

        public ArtistRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Artist> GetArtistWithSongsAsync(int artistId)
        {
            return await _context.Artists
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Id == artistId);
        }
    }
}