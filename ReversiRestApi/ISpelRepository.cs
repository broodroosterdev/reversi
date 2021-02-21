using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReversiRestApi
{
    public interface ISpelRepository
    {
        Task AddSpel(Game game);   
        public Task<List<Game>> GetSpellen();   
        Task<Game?> GetSpel(string spelToken);
        Task<Game?> GetSpelPlayer(string playerToken);
    }
}