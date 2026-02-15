namespace JwtKeyMusic.UI.Models
{
    public class ArtistDetailViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int SongCount { get; set; }
        public List<SongViewModel>? Songs { get; set; }
    }
}