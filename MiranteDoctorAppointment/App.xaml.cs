using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mirante.Framework.MiranteCFramework.DbContext;
using MiranteDoctorAppointment.Stores;
using MiranteDoctorAppointment.ViewModels;

namespace MiranteDoctorAppointment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AppDbContext? _dbContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Setup DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _dbContext = new AppDbContext(optionsBuilder.Options);

            // Ensure database is created
            _dbContext.Database.EnsureCreated();

            // Setup stores and viewmodels
            var appointmentStore = new AppointmentStore(_dbContext);
            var mainViewModel = new MainViewModel(appointmentStore);

            // Create and show main window
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _dbContext?.Dispose();
            base.OnExit(e);
        }
    }

}
