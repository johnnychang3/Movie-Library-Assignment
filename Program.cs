using System.Collections;
using System.Diagnostics.Metrics;
using System.IO;
using System.Runtime.CompilerServices;
using Helper;
using Microsoft.Extensions.DependencyInjection;
using Movie_Library_Assignment.Services;

namespace Movie_Library_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var startup = new Startup();
                var serviceProvider = startup.ConfigureServices();
                var service = serviceProvider.GetService<IMainService>();

                service?.Invoke();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }

        }
    }
}