using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReversiRestApi
{
    public class GameAccessLayer : ISpelRepository
    {
        private readonly RestApiContext _context;

        public GameAccessLayer(RestApiContext context)
        {
            _context = context;
        }
        public async Task AddSpel(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetSpellen()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetSpel(string spelToken)
        {
            return await _context.Games.FindAsync(spelToken);
        }

        public async Task<Game?> GetSpelPlayer(string playerToken)
        {
            return await _context.Games.Where(g => g.Player1Token == playerToken || g.Player2Token == playerToken)
                .SingleOrDefaultAsync();
        }
    }
}