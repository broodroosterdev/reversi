using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace ReversiRestApi
{
    public class RestApiContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public RestApiContext(DbContextOptions<RestApiContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Game>();
            builder.AddJsonFields();
        }
    }
}