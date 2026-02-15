using JwtKeyMusic.Business.Abstract;
using JwtKeyMusic.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtKeyMusic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSongHistoriesController : ControllerBase
    {
        private readonly IUserSongHistoryService _userSongHistoryService;

        public UserSongHistoriesController(IUserSongHistoryService userSongHistoryService)
        {
            _userSongHistoryService = userSongHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserSongHistory>>> GetAll()
        {
            var histories = await _userSongHistoryService.GetAllHistoriesAsync();
            return Ok(histories);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<UserSongHistory>>> GetByUserId(int userId)
        {
            var histories = await _userSongHistoryService.GetHistoryByUserAsync(userId);
            return Ok(histories);
        }

        [HttpPost]
        public async Task<ActionResult<UserSongHistory>> Create(UserSongHistory history)
        {
            await _userSongHistoryService.CreateHistoryAsync(history);
            return Ok(history);
        }
    }
}