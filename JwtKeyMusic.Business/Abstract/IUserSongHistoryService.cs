using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IUserSongHistoryService
    {
        Task<List<UserSongHistory>> GetAllHistoriesAsync();
        Task<List<UserSongHistory>> GetHistoryByUserAsync(int userId);
        Task CreateHistoryAsync(UserSongHistory history);
    }
}