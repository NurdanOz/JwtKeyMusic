namespace JwtKeyMusic.UI.Models
{
    public class SongViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public string? ArtistImageUrl { get; set; } 
        public string? ImageUrl { get; set; }
        public string? PreviewUrl { get; set; }
        public int RequiredLevel { get; set; }
        public string? YouTubeId { get; set; }
    }
}