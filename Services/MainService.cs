using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Services
{
    public class MainService : IMainService
    {
        public void Invoke()
        {
            var runService = new CsvFileService();
        }
    }
}
