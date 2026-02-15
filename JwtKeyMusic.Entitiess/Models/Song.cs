using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtKeyMusic.Entities.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public string ImageUrl { get; set; }
        public string PreviewUrl { get; set; }
        public int RequiredLevel { get; set; }

        
        public string? YouTubeId { get; set; }

        public ICollection<UserSongHistory> Histories { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }
}