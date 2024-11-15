using AdminClient.Controllers;
using AdminClient.ServiceManager.Interfaces.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMQ.Sockets;

namespace AdminClient
{
    internal static class Program
    {
        private static readonly RequestSocket rs = new("tcp://localhost:5557");
        private static IServiceProvider _serviceProvider { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            _serviceProvider = host.Services;
            Application.Run(_serviceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder() //set up dependency injection
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                /*services.AddSingleton<IReadingController, ReadingController>(
                    serviceProvider => new ReadingController(rs));
                services.AddSingleton<IMessageController, MessageController>();*/
                services.AddSingleton<IInstructionController, InstructionController>(
                    serviceProvider => new InstructionController(rs));
                services.AddTransient<Form1>();
            });
        }

    }
}