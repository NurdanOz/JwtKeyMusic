using JwtKeyMusic.DataAccess.Abstract;
using JwtKeyMusic.Entities.Models;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class PackageRepository : GenericRepository<Package>, IPackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}