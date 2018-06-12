using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AspnCore2Empty
{
    public class Startup
    {
       public IConfiguration _config { get; set; }
       public Startup(IHostingEnvironment env)
       {
           var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _config = builder.Build();

            if (env.IsDevelopment()){
                builder.AddApplicationInsightsSettings(developerMode:true);
            }
       }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                var mensagem = _config["Mensagem"];
                await context.Response.WriteAsync(mensagem);
            });
        }
    }
}
