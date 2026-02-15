using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class UserSongHistoryService : IUserSongHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSongHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserSongHistory>> GetAllHistoriesAsync()
        {
            return await _unitOfWork.UserSongHistories.GetAllAsync();
        }

        public async Task<List<UserSongHistory>> GetHistoryByUserAsync(int userId)
        {
            return await _unitOfWork.UserSongHistories.GetHistoryByUserAsync(userId);
        }

        public async Task CreateHistoryAsync(UserSongHistory history)
        {
            await _unitOfWork.UserSongHistories.AddAsync(history);
        }
    }
}