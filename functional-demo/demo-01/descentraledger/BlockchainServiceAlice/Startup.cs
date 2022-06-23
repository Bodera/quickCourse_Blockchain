using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace BlockchainServiceAlice
{
    public class Startup
    {
        // Defining policy name
        readonly string AllowedSpecificOrigins = "_allowedSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(o => o.AddPolicy(name: AllowedSpecificOrigins, builder => 
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "DescentraLedger API",
                    Description = "Blockchain API developed as part of the monograph to FATEC-Indaiatuba",
                    TermsOfService = new Uri("/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael N. Brito",
                        Email = "rafaelrafa990@gmail.com",
                        Url = new Uri("https://github.com/bodera")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Mozilla Public License v2.0",
                        Url = new Uri("https://www.mozilla.org/en-US/MPL/2.0/")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.) specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                //http://localhost:<port>/swagger
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DescentraLedger API v1");
            });

            app.UseRouting();

            app.UseCors(AllowedSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}