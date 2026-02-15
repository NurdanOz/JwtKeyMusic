using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}