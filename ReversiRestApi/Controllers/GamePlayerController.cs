using Microsoft.AspNetCore.Mvc;

namespace ReversiRestApi.Controllers
{
    [Route("api/SpelSpeler")]
    public class GamePlayerController : Controller
    {
        private readonly ISpelRepository repository;

        public GamePlayerController(ISpelRepository repository)
        {
            this.repository = repository;
        }

        // GET api/SpelSpeler/<spelertoken>
        [HttpGet("{spelertoken}")]
        public IActionResult GetSpelOfPlayer(string spelertoken)
        {
            var spel = repository.GetSpelPlayer(spelertoken);
            if (spel == null) return NotFound();
            return Ok(spel);
        }
    }
}