using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LunchService.Accessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace LunchService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public IContainer ApplicationContainer { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Lunch service", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");
                c.IncludeXmlComments(xmlPath);
            });

            var builder = new ContainerBuilder();

            builder.RegisterType<LunchManager>().AsSelf();
            builder.RegisterType<LunchAccessor>().As<ILunchAccessor>();
            builder.RegisterType<ConfigurationBasedConnectionString>().As<IConnectionStringProvider>();

            builder.Populate(services);
            ApplicationContainer = builder.Build();
            

            return new AutofacServiceProvider(ApplicationContainer);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Lunch API"); });    
        }
    }
}
