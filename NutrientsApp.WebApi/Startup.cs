using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NutrientsApp.Data;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Data.ImplEf.UnitOfWork;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "NutrientsApp.WebApi", Version = "v1"});
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IProductNutrientsService, ProductNutrientsService>();
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NutrientsDb"),
                    x => x.MigrationsAssembly("NutrientsApp.Data.ImplEf")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NutrientsApp.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}