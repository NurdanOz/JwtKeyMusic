namespace JwtKeyMusic.UI.Models
{
    public class RecommendationViewModel
    {
        public int SongId { get; set; }
        public string? Title { get; set; }
        public string? ArtistName { get; set; }
        public float PredictedScore { get; set; }
        public string? ImageUrl { get; set; }
        public string? PreviewUrl { get; set; }
    }
}