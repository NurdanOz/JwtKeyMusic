using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class PlaylistSongRepository : GenericRepository<PlaylistSong>, IPlaylistSongRepository
    {
        private readonly AppDbContext _context;

        public PlaylistSongRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PlaylistSong>> GetSongsByPlaylistAsync(int playlistId)
        {
            return await _context.PlaylistSongs.Where(ps => ps.PlaylistId == playlistId).ToListAsync();
        }
    }
}