using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Playlist>>> GetAll()
        {
            var playlists = await _playlistService.GetAllPlaylistsAsync();
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetById(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();
            return Ok(playlist);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Playlist>>> GetByUserId(int userId)
        {
            var playlists = await _playlistService.GetPlaylistsByUserAsync(userId);
            return Ok(playlists);
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> Create(Playlist playlist)
        {
            await _playlistService.CreatePlaylistAsync(playlist);
            return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Playlist playlist)
        {
            if (id != playlist.Id) return BadRequest();
            await _playlistService.UpdatePlaylistAsync(playlist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _playlistService.DeletePlaylistAsync(id);
            return NoContent();
        }
    }
}