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

            services.AddSingleton<IMainService, MainService>();

            return services.BuildServiceProvider();
        }
    }
}
