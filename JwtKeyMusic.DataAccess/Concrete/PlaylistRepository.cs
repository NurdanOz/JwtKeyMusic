using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        private readonly AppDbContext _context;

        public PlaylistRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Playlist>> GetPlaylistsByUserAsync(int userId)
        {
            return await _context.Playlists.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}