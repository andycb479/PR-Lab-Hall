using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall.Controllers;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Reflection;
using Hall.Core;

namespace Hall
{
     public class Startup
     {
          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }
          public void ConfigureServices(IServiceCollection services)
          {

               services.AddControllers();
               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hall", Version = "v1" });
               });

               services.AddHttpClient();

               services.AddSingleton<IHallRequestHandler, HallRequestHandler>();
               services.AddSingleton<HallCore>();

               services.AddAutoMapper(Assembly.GetAssembly(typeof(HallCore)));

          }

          public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HallCore hallCore)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hall v1"));
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
