using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Artist>>> GetAll()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null) return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> Create(Artist artist)
        {
            await _artistService.CreateArtistAsync(artist);
            return CreatedAtAction(nameof(GetById), new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Artist artist)
        {
            if (id != artist.Id) return BadRequest();
            await _artistService.UpdateArtistAsync(artist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.DeleteArtistAsync(id);
            return NoContent();
        }
    }
}