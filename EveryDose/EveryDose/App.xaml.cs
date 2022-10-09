using EveryDose.Database.DBConstant;
using EveryDose.Database.DBInterface;
using EveryDose.Database.DBOperation;
using EveryDose.DependencyServices;
using EveryDose.Model;
using EveryDose.View;
using EveryDose.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EveryDose
{
    public partial class App : Application
    {
        public SQLiteConnection conn;

        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();

            MainPage = new NavigationPage(new ProfileListPage());
        }

        protected override void OnStart()
        {
            SetDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<ProfileViewModel>();
            services.AddSingleton<DatabaseManager>();
            services.AddSingleton<IDatabaseOperation, DatabaseOperation>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Create sqlite database and create table
        /// </summary>
        private void SetDatabase()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.CreateTable(conn);
            
        }
    }
}
