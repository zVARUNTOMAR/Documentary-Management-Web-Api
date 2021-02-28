using DocumentaryManagementWebApi.BussinessLayer;
using DocumentaryManagementWebApi.DataLayer;
using DocumentaryManagementWebApi.DataLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocumentaryManagementWebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyAPI",
                    Description = "Testing"
                });
            });

            services.AddControllers();
            services.AddDbContextPool<DocumentaryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DocumentaryManagementContextConnectionString")));

            //BussinessLayer DI
            services.AddScoped<IDocumentaryBussinessLayer, DocumentaryBussinessLayer>();
            services.AddScoped<IActorBussinessLayer, ActorBussinessLayer>();

            //Data Layer DI
            services.AddScoped<IDocumentaryDataLayer, DocumentaryDataLayer>();
            services.AddScoped<IActorDataLayer, ActorDataLayer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });

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