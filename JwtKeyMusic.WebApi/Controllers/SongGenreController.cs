using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongGenresController : ControllerBase
    {
        private readonly ISongGenreService _songGenreService;

        public SongGenresController(ISongGenreService songGenreService)
        {
            _songGenreService = songGenreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SongGenre>>> GetAll()
        {
            var songGenres = await _songGenreService.GetAllSongGenresAsync();
            return Ok(songGenres);
        }

        [HttpPost]
        public async Task<ActionResult<SongGenre>> Create(SongGenre songGenre)
        {
            await _songGenreService.CreateSongGenreAsync(songGenre);
            return Ok(songGenre);
        }

        [HttpDelete("{songId}/{genreId}")]
        public async Task<IActionResult> Delete(int songId, int genreId)
        {
            await _songGenreService.DeleteSongGenreAsync(songId, genreId);
            return NoContent();
        }
    }
}