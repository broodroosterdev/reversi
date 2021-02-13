using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReversiRestApi.schemas;

namespace ReversiRestApi.Controllers
{
    [Route("api/Spel")]
    [ApiController]
    public class SpelController : Controller
    {
        private readonly ISpelRepository repository;

        public SpelController(ISpelRepository repository)
        {
            this.repository = repository;
        }
        
        // GET api/spel
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return Ok(repository.GetSpellen()
                .Where(spel => spel.Speler2Token == null)
                .Select(spel => spel.Omschrijving));
        }
        
        // POST api/spel
        [HttpPost]
        public IActionResult NieuwSpel([FromBody] NieuwSpel data)
        {
            var spel = new Spel();
            spel.Speler1Token = data.spelerToken;
            spel.Omschrijving = data.omschrijving;
            spel.Token = new Guid().ToString();
            repository.AddSpel(spel);
            return Ok();
        }

        // GET api/spel/<speltoken>
        [HttpGet("{speltoken}")]
        public IActionResult GetSpel([FromRoute] string speltoken)
        {
            var result = repository.GetSpel(speltoken);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        // ...
        
    }
}