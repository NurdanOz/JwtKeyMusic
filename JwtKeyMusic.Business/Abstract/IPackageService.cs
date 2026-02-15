using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Abstract
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllPackagesAsync();
        Task<Package> GetPackageByIdAsync(int id);
        Task CreatePackageAsync(Package package);
    }
}