using System.Collections.Generic;

namespace ReversiRestApi
{
    public interface ISpelRepository
    {
        void AddSpel(Game game);   
        public List<Game> GetSpellen();   
        Game? GetSpel(string spelToken);
        Game? GetSpelPlayer(string playerToken);
    }
}