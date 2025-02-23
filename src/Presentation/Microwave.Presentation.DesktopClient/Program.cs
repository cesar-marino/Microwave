using Microsoft.Extensions.DependencyInjection;
using Microwave.Presentation.DesktopClient.Microwave;

namespace Microwave.Presentation.DesktopClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _ = serviceCollection.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void ConfigureServices(ServiceCollection service)
        {
            service.AddScoped<IMicrowaveService, MicrowaveService>();
        }
    }
}