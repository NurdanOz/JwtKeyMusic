// Models/ArtistViewModel.cs
namespace JwtKeyMusic.UI.Models
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int SongCount { get; set; }
    }
}