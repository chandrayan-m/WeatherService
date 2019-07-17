using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PrudentialWeatherService.Model;
using WeatherService.Repository.Entity;
using WeatherService.Repository.Middleware;
using WeatherService.Repository.Repository;

namespace PrudentialWeatherService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMiddleware, Middleware>();
            services.AddTransient<IWeatherRepository, WeatherRepository>();

            services.Configure<ConfigurationItem>(Configuration.GetSection("AppSettings"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Create the container builder.
            //var builder = new ContainerBuilder();
            //builder.RegisterType<Middleware>().As<IMiddleware>().InstancePerRequest();
            //builder.RegisterType<WeatherRepository>().As<IWeatherRepository>()
            //    .WithParameter("baseUrl", Configuration["AppSettings:baseAddress"])
            //    .WithParameter("apiId", Configuration["AppSettings:apiId"]).InstancePerRequest();
            
            //builder.Populate(services);
            //this.ApplicationContainer = builder.Build();
            //// Create the IServiceProvider based on the container.
            //return new AutofacServiceProvider(this.ApplicationContainer);
                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
