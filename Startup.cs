using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movie_Library_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine("we are in startup");
            services.AddSingleton<IMainService, MainService>();
            services.AddSingleton<IFileService, CsvFileService>();

            return services.BuildServiceProvider();
        }
    }
}
