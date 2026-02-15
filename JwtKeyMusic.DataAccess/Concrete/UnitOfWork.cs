using JwtKeyMusic.DataAccess.Abstract;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; private set; }
        public IArtistRepository Artists { get; private set; }
        public ISongRepository Songs { get; private set; }
        public IPlaylistRepository Playlists { get; private set; }
        public IPlaylistSongRepository PlaylistSongs { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public ISongGenreRepository SongGenres { get; private set; }
        public IPackageRepository Packages { get; private set; }
        public IUserSongHistoryRepository UserSongHistories { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Artists = new ArtistRepository(context);
            Songs = new SongRepository(context);
            Playlists = new PlaylistRepository(context);
            PlaylistSongs = new PlaylistSongRepository(context);
            Genres = new GenreRepository(context);
            SongGenres = new SongGenreRepository(context);
            Packages = new PackageRepository(context);
            UserSongHistories = new UserSongHistoryRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}