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
        private SpelController _spelController;
        private ISpelRepository _repo;
        private List<Spel> _spellen = new List<Spel>();
        
        private Spel _spelWithSecondPlayer = new Spel() {Speler1Token = "test", Speler2Token = "test", Omschrijving = "test"};
        private Spel _spelWithoutSecondPlayer = new Spel() {Speler1Token = "test", Omschrijving = "test"};
        
        
        [SetUp]
        public void Setup()
        {
            _repo = Substitute.For<ISpelRepository>();
            
            _spelController = new SpelController(_repo);
        }

        [Test]
        public void GetSpellenMetWachtendeSpeler_ReturnsOmschrijvingen()
        {
            _repo.GetSpellen().Returns(new List<Spel>(){_spelWithSecondPlayer, _spelWithoutSecondPlayer});
            var response = _spelController.GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler();
            var result = response.Result as OkObjectResult;
            Assert.IsNotNull(result);
            var spellen = (result.Value as IEnumerable<string>).ToList();
            Assert.AreEqual(1, spellen.Count);
            Assert.AreEqual(_spelWithoutSecondPlayer.Omschrijving, spellen[0]);
        }

        [Test]
        public void NieuwSpel_AddsToRepo()
        {
            var repo = new SpelRepository();
            var controller = new SpelController(repo);
            var result = controller.NieuwSpel(new NieuwSpel() {omschrijving = "omschrijving", spelerToken = "token"}) as OkResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(4, repo.Spellen.Count);
        }

    }
}