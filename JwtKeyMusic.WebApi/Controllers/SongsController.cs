using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly IGeminiService _geminiService;
        private readonly IGenreService _genreService; // Hata giderildi: Alan eklendi
        private readonly ISongGenreService _songGenreService; // Hata giderildi: Alan eklendi

        public SongsController(
            ISongService songService,
            IArtistService artistService,
            IGeminiService geminiService,
            IGenreService genreService, // Constructor enjeksiyonu
            ISongGenreService songGenreService) // Constructor enjeksiyonu
        {
            _songService = songService;
            _artistService = artistService;
            _geminiService = geminiService;
            _genreService = genreService;
            _songGenreService = songGenreService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll()
        {
            var songs = await _songService.GetAllSongsAsync();
            var artistIds = songs.Select(s => s.ArtistId).Distinct().ToList();
            var artists = new Dictionary<int, Artist>();

            foreach (var artistId in artistIds)
            {
                var artist = await _artistService.GetArtistByIdAsync(artistId);
                if (artist != null) artists[artistId] = artist;
            }

            var songsWithArtists = songs.Select(song => new
            {
                id = song.Id,
                title = song.Title,
                artistId = song.ArtistId,
                artistName = artists.ContainsKey(song.ArtistId) ? artists[song.ArtistId].Name : "Bilinmeyen Sanatçı",
                artistImageUrl = artists.ContainsKey(song.ArtistId) ? artists[song.ArtistId].ImageUrl : null,
                imageUrl = song.ImageUrl,
                previewUrl = song.PreviewUrl,
                requiredLevel = song.RequiredLevel,
                youtubeId = song.YouTubeId
            }).ToList();

            return Ok(songsWithArtists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetById(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        [Authorize]
        [HttpGet("{id}/CanPlay")]
        public async Task<ActionResult<object>> CanPlaySong(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null) return NotFound(new { message = "Şarkı bulunamadı" });

            var packageLevelClaim = User.FindFirst("packageLevel");
            if (packageLevelClaim == null) return Unauthorized(new { message = "Token geçersiz" });

            if (!int.TryParse(packageLevelClaim.Value, out int userPackageLevel))
                return Unauthorized(new { message = "Package level okunamadı" });

            bool canPlay = userPackageLevel >= song.RequiredLevel;

            return Ok(new
            {
                canPlay = canPlay,
                songId = id,
                songTitle = song.Title,
                requiredLevel = song.RequiredLevel,
                userPackageLevel = userPackageLevel,
                message = canPlay ? "Dinleyebilirsin ✅" : "Bu şarkı için daha yüksek paket gerekli"
            });
        }

        [HttpPost]
        public async Task<ActionResult<Song>> Create(Song song)
        {
            await _songService.CreateSongAsync(song);
            return CreatedAtAction(nameof(GetById), new { id = song.Id }, song);
        }

        [HttpGet("popular")]
        public async Task<ActionResult<object>> GetPopularSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            var popularSongs = songs.OrderBy(s => s.Id).Take(5).ToList();
            var result = new List<object>();

            foreach (var song in popularSongs)
            {
                var artist = await _artistService.GetArtistByIdAsync(song.ArtistId);
                result.Add(new
                {
                    id = song.Id,
                    title = song.Title,
                    artistName = artist?.Name ?? "Bilinmeyen Sanatçı",
                    imageUrl = song.ImageUrl,
                    previewUrl = song.PreviewUrl
                });
            }
            return Ok(result);
        }

        // --- AI SEARCH ENDPOINT (EN GÜNCEL HALİ) ---
        [HttpGet("AiSearch")]
        public async Task<ActionResult<object>> AiSearch(string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
                return BadRequest(new { message = "Lütfen bir arama metni girin." });

            var aiResult = await _geminiService.AnalyzePromptAsync(prompt);

            if (aiResult == null || aiResult.Genres == null || !aiResult.Genres.Any())
            {
                return Ok(new
                {
                    message = "Modunuza uygun bir şarkı türü belirlenemedi.",
                    songs = new List<object>()
                });
            }

            var allGenres = await _genreService.GetAllGenresAsync();
            var matchedGenreIds = allGenres
                .Where(g => aiResult.Genres.Any(aiG =>
                    g.Name.Contains(aiG, StringComparison.OrdinalIgnoreCase) ||
                    aiG.Contains(g.Name, StringComparison.OrdinalIgnoreCase)))
                .Select(g => g.Id)
                .ToList();

            var songGenres = await _songGenreService.GetAllSongGenresAsync();
            var filteredSongIds = songGenres
                .Where(sg => matchedGenreIds.Contains(sg.GenreId))
                .Select(sg => sg.SongId)
                .Distinct()
                .ToList();

            var allSongs = await _songService.GetAllSongsAsync();
            var filteredSongs = allSongs.Where(s => filteredSongIds.Contains(s.Id)).ToList();

            var finalResult = new List<object>();
            foreach (var song in filteredSongs)
            {
                var artist = await _artistService.GetArtistByIdAsync(song.ArtistId);
                finalResult.Add(new
                {
                    id = song.Id,
                    title = song.Title,
                    artistName = artist?.Name ?? "Bilinmeyen Sanatçı",
                    imageUrl = song.ImageUrl,
                    previewUrl = song.PreviewUrl,
                    aiMood = aiResult.Mood
                });
            }

            return Ok(new
            {
                mood = aiResult.Mood,
                songs = finalResult
            });
        }
    }
}