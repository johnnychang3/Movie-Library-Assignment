using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movie_Library_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Movie_Library_Assignment.Services.CSVFileService;
using Movie_Library_Assignment.Services.JsonFileService;

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
            Console.WriteLine("-----------------------------");
            Console.WriteLine("          Main Menu          ");
            Console.WriteLine("-----------------------------");
            while (!exit)
            {
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
                    Console.WriteLine("Good Bye!");
                    Environment.Exit(0);                    
                }
            }

            return services.BuildServiceProvider();
        }
    }
}
