using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly AppDbContext _context;

        public SongRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetSongsByArtistAsync(int artistId)
        {
            return await _context.Songs.Where(s => s.ArtistId == artistId).ToListAsync();
        }

        public async Task<List<Song>> GetSongsByGenreAsync(int genreId)
        {
            return await _context.Songs
                .Include(s => s.SongGenres)
                .Where(s => s.SongGenres.Any(sg => sg.GenreId == genreId))
                .ToListAsync();
        }
    }
}