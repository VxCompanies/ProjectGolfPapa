using Microsoft.Extensions.Configuration;
using ProjectGolfPapa.ViewModels;
using ProjectGolfPapa.ViewModels.Service;
using System.Windows;

namespace ProjectGolfPapa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IConfiguration _configuration;

        public static readonly string mongoDbConnectionString = _configuration.GetConnectionString("mongoDb");

        protected override void OnStartup(StartupEventArgs e)
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            NavigationService.MainNavigate(new IndexViewModel());
            NavigationService.IndexNavigate(new HomeViewModel());

            new MainWindow()
            {
                DataContext = new MainViewModel()
            }
            .Show();

            base.OnStartup(e);
        }
    }
}
