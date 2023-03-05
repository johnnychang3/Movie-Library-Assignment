using Helper;
using Movie_Library_Assignment.Context;


namespace Movie_Library_Assignment.Services
{
    public class JsonFileService : IFileService
    {
        public void Menu() // Main Menu
        {
            bool menuExit = false;

            Console.Clear();
            while (!menuExit)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("  JSON File Media Main Menu  ");
                Console.WriteLine("-----------------------------");

                var userInput = Input.GetIntWithPrompt("1. Add New Media\n2. Display Media\n\n0. Exit\nChoose Option: ", "Choose a valid option.");
                switch (userInput)
                {
                    case 1:
                        Write();
                        Console.Clear();
                        break;

                    case 2:
                        Display();
                        Console.Clear();
                        break;
                    case 0:
                        menuExit = true;
                        Console.Clear();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("           Good Bye          ");
                        Console.WriteLine("-----------------------------");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choose a valid option.\n");
                        break;
                }
            }
        }

        public void Write() // Write
        {
            MediaContext context = new MediaContext();
            Repository repo = new Repository(context);

            Console.Clear();
            repo.WriteJson();
        }

        public void Display() // Display
        {
            MediaContext context = new MediaContext();
            Repository repo = new Repository(context);
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("         Display Menu        ");
                Console.WriteLine("-----------------------------");
                var userInput = Input.GetIntWithPrompt("1. Display Media by Type\n2. Display Media by Title\n\n0. Go Back\nChoose Option: ", "Choose a valid option: ");

                if (userInput == 1) // Display by Type
                {
                    Console.Clear();
                    repo.SearchByTypeJson();

                    exit = true;
                }
                else if (userInput == 2) // Display by Title
                {
                    Console.Clear();
                    repo.SearchByTitleJson();

                    exit = true;
                }
                else if (userInput == 0) // Exit
                {
                    Console.Clear();
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Choose a valid option");
                }
            } while (!exit);
        }
    }
}
