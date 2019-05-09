using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace IataCodes
{
    public class Startup
    {
        private const string ApiName = "Airports API";
        private const string ApiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient(typeof(AirportsContext));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowEveryone", policy => policy.AllowAnyOrigin());
            });
            ConfigureSwagger(services);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new Info { Title = ApiName, Version = ApiVersion });
                c.IncludeXmlComments(Path.Combine(GetXmlCommentsFilePath(), "IataCodes.xml"));
            });
        }

        private static string GetXmlCommentsFilePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiName} ${ApiVersion}");
            });
            app.UseMvc();
        }
    }
}
