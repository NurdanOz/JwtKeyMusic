using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetAll()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null) return NotFound();
            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<Package>> Create(Package package)
        {
            await _packageService.CreatePackageAsync(package);
            return CreatedAtAction(nameof(GetById), new { id = package.Id }, package);
        }
    }
}