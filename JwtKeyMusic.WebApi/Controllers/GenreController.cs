using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetAll()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> Create(Genre genre)
        {
            await _genreService.CreateGenreAsync(genre);
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}