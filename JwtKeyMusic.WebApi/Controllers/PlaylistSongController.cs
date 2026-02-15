using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongsController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlaylistSong>>> GetAll()
        {
            var playlistSongs = await _playlistSongService.GetAllPlaylistSongsAsync();
            return Ok(playlistSongs);
        }

        [HttpGet("playlist/{playlistId}")]
        public async Task<ActionResult<List<PlaylistSong>>> GetByPlaylistId(int playlistId)
        {
            var songs = await _playlistSongService.GetSongsByPlaylistAsync(playlistId);
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistSong>> Create(PlaylistSong playlistSong)
        {
            await _playlistSongService.CreatePlaylistSongAsync(playlistSong);
            return Ok(playlistSong);
        }

        [HttpDelete("{playlistId}/{songId}")]
        public async Task<IActionResult> Delete(int playlistId, int songId)
        {
            await _playlistSongService.DeletePlaylistSongAsync(playlistId, songId);
            return NoContent();
        }
    }
}