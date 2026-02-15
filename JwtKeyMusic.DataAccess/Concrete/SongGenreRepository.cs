using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class SongGenreRepository : GenericRepository<SongGenre>, ISongGenreRepository
    {
        private readonly AppDbContext _context;

        public SongGenreRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}