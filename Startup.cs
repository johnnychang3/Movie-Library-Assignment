using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movie_Library_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Movie_Library_Assignment
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });

            services.AddSingleton<IMainService, MainService>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("          Main Menu          ");
                Console.WriteLine("-----------------------------");
                var userInput = Input.GetIntWithPrompt("1. CSV File Reader\n2. JSON File Reader\n\n0. Exit\nChoose option: ", "Choose a valid option: ");
                if (userInput == 1)
                {
                    services.AddSingleton<IFileService, CsvFileService>();
                    exit = true;
                }
                else if (userInput == 2)
                {
                    services.AddSingleton<IFileService, JsonFileService>();
                    exit = true;
                }
                else if (userInput == 0)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("          Good Bye          ");
                    Console.WriteLine("-----------------------------");
                    Environment.Exit(0);                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Choose a valid option.");
                }
            }

            return services.BuildServiceProvider();
        }
    }
}
