﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ReversiRestApi;
using ReversiRestApi.Controllers;

namespace ReversiTest
{
    public class SpelSpelerControllerTest
    {
        private GamePlayerController _controller = new GamePlayerController(new SpelRepository());

        [Test]
        public void GetSpelOfPlayer_ReturnsGameOfPlayer()
        {
            var result = _controller.GetSpelOfPlayer("abcdef") as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.AreEqual("abcdef", ((Game) result.Value).Player1Token);
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