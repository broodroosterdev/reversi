using System.Threading.Tasks;
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
        public async Task<IActionResult> GetSpelOfPlayer(string spelertoken)
        {
            var spel = await repository.GetSpelPlayer(spelertoken);
            if (spel == null) return NotFound();
            return Ok(spel);
        }
    }
}