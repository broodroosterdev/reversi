using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using ReversiRestApi;
using ReversiRestApi.Controllers;
using ReversiRestApi.schemas;

namespace ReversiTest
{
    public class SpelControllerTest
    {
        private GameController _gameController;
        private ISpelRepository _repo;
        private List<Game> _spellen = new List<Game>();
        
        private Game _gameWithSecondPlayer = new Game() {Player1Token = "test", Player2Token = "test", Description = "test"};
        private Game _gameWithoutSecondPlayer = new Game() {Player1Token = "test", Description = "test"};
        
        
        [SetUp]
        public void Setup()
        {
            _repo = Substitute.For<ISpelRepository>();
            
            _gameController = new GameController(_repo);
        }

        [Test]
        public void GetSpellenMetWachtendeSpeler_ReturnsOmschrijvingen()
        {
            _repo.GetSpellen().Returns(new List<Game>(){_gameWithSecondPlayer, _gameWithoutSecondPlayer});
            var response = _gameController.GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler();
            var result = response.Result as OkObjectResult;
            Assert.IsNotNull(result);
            var spellen = (result.Value as IEnumerable<string>).ToList();
            Assert.AreEqual(1, spellen.Count);
            Assert.AreEqual(_gameWithoutSecondPlayer.Description, spellen[0]);
        }

        [Test]
        public void NieuwSpel_AddsToRepo()
        {
            var repo = new SpelRepository();
            var controller = new GameController(repo);
            var result = controller.NieuwSpel(new NewGame() {Description = "omschrijving", PlayerToken = "token"}) as OkResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(4, repo.Spellen.Count);
        }

        [Test]
        public void GetSpel_ReturnsExisting()
        {
            var repo = new SpelRepository();
            var controller = new GameController(repo);
            var result = controller.GetSpel("test") as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.AreEqual("test", ((Game) result.Value).Token);
        }

        [Test]
        public void GetSpel_ErrorsOnNonExisting()
        {
            var repo = new SpelRepository();
            var controller = new GameController(repo);
            var result = controller.GetSpel("doesnt-exist") as NotFoundResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

    }
}