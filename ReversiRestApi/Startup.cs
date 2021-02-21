using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ReversiRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestApiContext>(options =>
            {
                options.UseSqlServer(
                    "Server=test-debian.fritz.box,1433;Database=ReversiRest;User Id=SA;Password=NCDfydN8DjJS6cB6;");
            });
            var builder = new DbContextOptionsBuilder<RestApiContext>();
            builder.UseSqlServer(
                "Server=test-debian.fritz.box,1433;Database=ReversiRest;User Id=SA;Password=NCDfydN8DjJS6cB6;");
            services.AddSingleton<ISpelRepository, GameAccessLayer>(services => new GameAccessLayer(new RestApiContext(builder.Options)));
            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}