using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Movie_Library_Assignment.Services
{
    public class JsonFileService : IFileService
    {
        public void Menu()
        {
            bool menuExit = false;

            Console.WriteLine("Movie Library");
            Console.WriteLine("-------------\n");
            while (!menuExit)
            {
                Console.WriteLine("JSON File Main Menu");
                Console.WriteLine("-------------------");

                var userInput = Input.GetIntWithPrompt("1. Add New Movie\n2. Display Movies\n3. Exit\nChoose Option: ", "Choose a valid option.");
                switch (userInput)
                {
                    case 1:
                        Write();
                        break;

                    case 2:
                        Display();
                        break;
                    case 3:
                        menuExit = true;
                        Console.WriteLine("Good Bye!\n");
                        break;
                }
            }

        }

        public void Write ()
        {

        }

        public void Display()
        {

        }
    }
}
