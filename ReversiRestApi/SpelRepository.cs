using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi
{
    public class SpelRepository : ISpelRepository
    {
        // Lijst met tijdelijke spellen
        public List<Game> Spellen { get; set; }

        public SpelRepository()
        {
            Game spel1 = new Game();
            Game spel2 = new Game();
            Game spel3 = new Game();
            spel1.Token = "test";
            spel1.Player1Token = "abcdef";
            spel1.Description = "Potje snel reversi, dus niet lang nadenken";
            spel2.Token = "spel2";
            spel2.Player1Token = "ghijkl";   
            spel2.Player2Token = "mnopqr";      
            spel2.Description = "Ik zoek een gevorderde tegenspeler!";     
            spel3.Player1Token = "stuvwx";        
            spel3.Description = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";         
            Spellen = new List<Game> {spel1, spel2, spel3};
        }
        
        public Task AddSpel(Game game)
        {
            return Task.Run(() =>
            {
                Spellen.Add(game);
                
            });
        }

        public Task<List<Game>> GetSpellen()
        {
            return Task<List<Game>>.Factory.StartNew(() => Spellen);
        }
        
        public Task<Game?> GetSpel(string spelToken)
        {
            return Task<Game?>.Factory.StartNew(() =>
            {
                try
                {
                    return Spellen.First(spel => spel.Token == spelToken);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            });
        }

        public Task<Game?> GetSpelPlayer(string playerToken)
        {
            return Task<Game?>.Factory.StartNew(() =>
            {
                try
                {
                    return Spellen.First(spel => spel.Player1Token == playerToken);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            });
        }
    }
}