using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using Helper;

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
            _fileService.Menu();
        }
    }
}
