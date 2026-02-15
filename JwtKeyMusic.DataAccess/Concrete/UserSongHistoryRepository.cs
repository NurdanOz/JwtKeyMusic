using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class UserSongHistoryRepository : GenericRepository<UserSongHistory>, IUserSongHistoryRepository
    {
        private readonly AppDbContext _context;

        public UserSongHistoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserSongHistory>> GetHistoryByUserAsync(int userId)
        {
            return await _context.UserSongHistories.Where(uh => uh.UserId == userId).ToListAsync();
        }
    }
}