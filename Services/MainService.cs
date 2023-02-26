using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Movie_Library_Assignment.Services
{
    public class MainService : IMainService
    {
        
        private IFileService _fileService;
        public MainService(IFileService fileService) 
        {
            _fileService = fileService;
        }
        public void Invoke()
        {
            try
            {
                //var runService = new CsvFileService();
                Console.WriteLine("Main Service");
                Console.WriteLine("enter option:");
                var userInput = Console.ReadLine();
                if (userInput != null) { _fileService.Menu();}
                
            }
            catch (Exception ex) { Console.WriteLine(ex); throw; }
        }
    }
}
