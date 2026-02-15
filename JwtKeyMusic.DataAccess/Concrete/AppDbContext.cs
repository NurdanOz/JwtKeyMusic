using JwtKeyMusic.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtKeyMusic.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSongHistory> UserSongHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaylistSong>().HasKey(ps => new { ps.PlaylistId, ps.SongId });
            modelBuilder.Entity<SongGenre>().HasKey(sg => new { sg.SongId, sg.GenreId });
        }
    }
}