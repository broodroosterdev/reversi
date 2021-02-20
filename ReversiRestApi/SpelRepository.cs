using System;
using System.Collections.Generic;
using System.Linq;

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
        
        public void AddSpel(Game game)    
        {   
            Spellen.Add(game);
        }

        public List<Game> GetSpellen()
        {
            return Spellen;
        }
        
        public Game? GetSpel(string spelToken)
        {
            try
            {
                return Spellen.First(spel => spel.Token == spelToken);
            }
            catch (InvalidOperationException _)
            {
                return null;
            }
        }

        public Game? GetSpelPlayer(string playerToken)
        {
            try
            {
                return Spellen.First(spel => spel.Player1Token == playerToken);
            }
            catch (InvalidOperationException _)
            {
                return null;
            } 
        }
    }
}