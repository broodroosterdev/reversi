using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ReversiRestApi;
using ReversiRestApi.Controllers;

namespace ReversiTest
{
    public class SpelSpelerControllerTest
    {
        private SpelSpelerController _controller = new SpelSpelerController(new SpelRepository());

        [Test]
        public void GetSpelOfPlayer_ReturnsGameOfPlayer()
        {
            var result = _controller.GetSpelOfPlayer("abcdef") as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.AreEqual("abcdef", ((Spel) result.Value).Speler1Token);
        }

        [Test]
        public void GetSpelOfPlayer_ReturnsErrorWhenNotInGame()
        {
            var result = _controller.GetSpelOfPlayer("notplayer") as NotFoundResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }
        
        
    }
}