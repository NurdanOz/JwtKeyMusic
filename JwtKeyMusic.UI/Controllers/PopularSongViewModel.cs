namespace JwtKeyMusic.UI.Models
{
    public class PopularSongViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ArtistName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string PreviewUrl { get; set; } = null!;
    }
}