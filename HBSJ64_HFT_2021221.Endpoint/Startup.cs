using HBSJ64_HFT_2021221.Data;
using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddTransient<IFilmLogic, FilmLogic>();
            services.AddTransient<IActorLogic, ActorLogic>();
            services.AddTransient<IDirectorLogic, DirectorLogic>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<FilmDbContext, FilmDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
