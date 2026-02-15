using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
    }
}