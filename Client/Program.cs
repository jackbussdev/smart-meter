using NetMQ.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Client.ServiceManager.Interfaces.Controllers.Communication;
using Client.Controllers.Communication;

namespace Client
{
    internal static class Program
    {
        private static readonly RequestSocket rs = new("tcp://localhost:5556");
        private static int _serialNumber = 0;
        private static int _locationId = 0;
        private static IServiceProvider _serviceProvider { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Validate and assign arguments (improved version)
            if (args.Length < 2)
            {
                MessageBox.Show("Please provide both Client ID and Location ID arguments!");
                return;
            }

            try
            {
                _serialNumber = Int32.Parse(args[0]);
                _locationId = Int32.Parse(args[1]);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format for Client ID or Location ID!");
                return;
            }

            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            _serviceProvider = host.Services;
            Application.Run(_serviceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder() //set up dependency injection
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<IReadingController, ReadingController>(
                    serviceProvider => new ReadingController(rs, _serialNumber, _locationId));
                services.AddSingleton<IMessageController, MessageController>();
                services.AddTransient<Form1>();
            });
        }

    }
}