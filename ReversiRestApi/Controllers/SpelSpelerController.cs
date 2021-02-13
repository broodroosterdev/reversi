using Microsoft.AspNetCore.Mvc;

namespace ReversiRestApi.Controllers
{
    [Route("api/SpelSpeler")]
    public class SpelSpelerController : Controller
    {
        private readonly ISpelRepository repository;

        public SpelSpelerController(ISpelRepository repository)
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