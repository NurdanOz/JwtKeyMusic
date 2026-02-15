using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.Business.Concrete
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _unitOfWork.Packages.GetAllAsync();
        }

        public async Task<Package> GetPackageByIdAsync(int id)
        {
            return await _unitOfWork.Packages.GetByIdAsync(id);
        }

        public async Task CreatePackageAsync(Package package)
        {
            await _unitOfWork.Packages.AddAsync(package);
        }
    }
}