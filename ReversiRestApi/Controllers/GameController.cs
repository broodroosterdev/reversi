using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReversiRestApi.schemas;

namespace ReversiRestApi.Controllers
{
    [Route("api/Spel")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly ISpelRepository repository;

        public GameController(ISpelRepository repository)
        {
            this.repository = repository;
        }
        
        // GET api/Spel
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return Ok(repository.GetSpellen()
                .Where(spel => spel.Player2Token == null)
                .Select(spel => spel.Description));
        }
        
        // POST api/Spel
        [HttpPost]
        public IActionResult NieuwSpel([FromBody] NewGame data)
        {
            var spel = new Game();
            spel.Player1Token = data.PlayerToken;
            spel.Description = data.Description;
            spel.Token = new Guid().ToString();
            repository.AddSpel(spel);
            return Ok();
        }

        // GET api/Spel/<speltoken>
        [HttpGet("{speltoken}")]
        public IActionResult GetSpel([FromRoute] string speltoken)
        {
            var result = repository.GetSpel(speltoken);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/Spel/Beurt/<speltoken>
        [HttpGet("Beurt/{speltoken}")]
        public IActionResult GetBeurt([FromRoute] string speltoken)
        {
            var result = repository.GetSpel(speltoken);
            if (result == null) return NotFound();
            return Ok(result.Turn);
        }

        [HttpPut("Zet")]
        public IActionResult PutZet([FromBody] Move move)
        {
            var spelFromRepo = repository.GetSpel(move.GameToken);
            if (spelFromRepo == null) return NotFound("SpelNotFound");
            Game game =  spelFromRepo;
            var aanDeBeurt = game.Turn == Color.White ? game.Player1Token : game.Player2Token;
            if (move.PlayerToken != aanDeBeurt) return BadRequest("NietAanDeBeurt");
            if (move.Pass)
            {
                if (!game.Pass())
                    return BadRequest("KanGeenPas");
                return Ok();
            }
            else
            {
                if (move.Col == null || move.Row == null) return BadRequest();
                if (!game.DoMove((int) move.Row, (int) move.Col))
                    return BadRequest("ZetOnmogelijk");

                return Ok();
            }
        }

        [HttpPut("Opgeven")]
        public IActionResult PutOpgeven([FromBody] Resign data)
        {
            var spelFromRepo = repository.GetSpel(data.GameToken);
            if (spelFromRepo == null) return NotFound("SpelNotFound");
            Game game = spelFromRepo;
            var aanDeBeurt = game.Turn == Color.White ? game.Player1Token : game.Player2Token;
            if (data.PlayerToken != aanDeBeurt) return BadRequest();
            if (game.Resign())
            {
                return Ok();
            }

            return BadRequest();
        }
        
        
        
        // ...
        
    }
}