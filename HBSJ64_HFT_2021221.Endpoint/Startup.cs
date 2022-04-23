using HBSJ64_HFT_2021221.Data;
using HBSJ64_HFT_2021221.Endpoint.Services;
using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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

            services.AddTransient<IFilmLogic, FilmLogic>();
            services.AddTransient<IActorLogic, ActorLogic>();
            services.AddTransient<IDirectorLogic, DirectorLogic>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<FilmDbContext, FilmDbContext>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HBSJ64_HFT_2021221.Endpoint", Version = "v1" });
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:11171"));

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });



            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HBSJ64_HFT2021221.Endpoint v1"));
        }
    }
}
