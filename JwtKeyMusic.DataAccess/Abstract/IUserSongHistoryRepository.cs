using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IUserSongHistoryRepository : IGenericRepository<UserSongHistory>
    {
        Task<List<UserSongHistory>> GetHistoryByUserAsync(int userId);
    }
}