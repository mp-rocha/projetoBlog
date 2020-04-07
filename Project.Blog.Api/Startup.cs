using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto.Blog.Data.Context;
using Projeto.Blog.Data.Repository;
using Projeto.Blog.Domain.Configuration;
using Projeto.Blog.Domain.IRepository;
using Projeto.Blog.Domain.IService;
using Projeto.Blog.Service.Service;

namespace Project.Blog.Api
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
            services.AddControllers();

            // Injeção de Dependecia
            services.Configure<Config>(Configuration);
            services.AddScoped<ContextoMongoDB>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IServicePublicacao, ServicePublicacao>();
            services.AddHealthChecks().AddMongoDb(Configuration["ConnectionString"], mongoDatabaseName: Configuration["DatabaseName"]);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
