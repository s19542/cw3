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

namespace Cw3
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //
            app.UseDeveloperExceptionPage();

            app.UseRouting();//jezeli nie jest na produkcji

            //////////////////////////////////////////
            //   app.UseHttpsRedirection();//перенаправляє назад якщо протокол не https 
            //не пропускає в наст міддлваре

            //доклеює до відповіді наглувек http
            app.Use(async (contex, c)=>{
                contex.Response.Headers.Add("Secret", "123");
                await c.Invoke();//пропускаэ запрос в наст міддлваре
            });
            ///////////////////////////////////

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
