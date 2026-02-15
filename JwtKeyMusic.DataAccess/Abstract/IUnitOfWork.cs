namespace JwtKeyMusic.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IArtistRepository Artists { get; }
        ISongRepository Songs { get; }
        IPlaylistRepository Playlists { get; }
        IPlaylistSongRepository PlaylistSongs { get; }
        IGenreRepository Genres { get; }
        ISongGenreRepository SongGenres { get; }
        IPackageRepository Packages { get; }
        IUserSongHistoryRepository UserSongHistories { get; }

        Task SaveAsync();
    }
}