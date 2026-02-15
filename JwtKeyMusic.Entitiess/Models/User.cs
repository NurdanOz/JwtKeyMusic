using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtKeyMusic.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PackageId { get; set; }  
        public Package Package { get; set; }

        public ICollection<UserSongHistory> SongHistories { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }

}