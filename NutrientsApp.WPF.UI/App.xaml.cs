using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NutrientsApp.Data;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Data.ImplOrmLite.UnitOfWork;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;
using NutrientsApp.WPF.UI.ViewModels;
using ServiceStack.OrmLite;

namespace NutrientsApp.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Console.WriteLine(Configuration.GetConnectionString("NutrientsDb"));

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        private void ConfigureServices(IServiceCollection services)
        {
            OrmLiteConnectionFactory connectionFactory = new OrmLiteConnectionFactory(Configuration.GetConnectionString("NutrientsDb"), SqlServer2019Dialect.Provider);
            services.AddSingleton<OrmLiteConnectionFactory>(connectionFactory);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<MainWindow>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IIngredientsService, IngredientService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IProductNutrientsService, ProductNutrientsService>();
            services.AddTransient<INutrientComponentsService, NutrientComponentsService>();
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NutrientsDb"),
                    x => x.MigrationsAssembly("NutrientsApp.Data.ImplEf")));
            services.AddTransient<ApplicationViewModel>();
        }
    }
}