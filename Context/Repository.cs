using Helper;

namespace Movie_Library_Assignment.Context
{
    public class Repository
    {
        private MediaContext _mediaContext;

        public Repository(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }

        public void SearchByTypeJson() // Display all by media type JSON 
        {
            bool exit = false;
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("           Display           ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Which media do you want to display?");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Return to Main Menu\nChoose Option: ", "Please enter a valid option.");
                Console.Clear();
                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesJson();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Movies)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsJson();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("            Shows            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Shows)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosJson();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Videos            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Videos)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.\n");
                    Console.Clear();
                }
            } while (!exit);
        }

        public void SearchByTitleJson() // Display media by Title JSON file
        {
            bool exit = false;
            do
            {
                bool match = false;

                Console.WriteLine("-----------------------------");
                Console.WriteLine("           Display           ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Select Media type to search");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Return to Main Menu\nChoose Option: ", "Choose a valid option.");
                Console.Clear();

                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Movie title: ", "Movie title required.\nEnter Movie title: ");

                    foreach (var movie in _mediaContext.Movies)
                    {
                        if (movie.Title.ToLower() == userInputTitle.ToLower())
                        {
                            movie.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Show title: ", "Show title required.\nEnter Show title: ");

                    foreach (var show in _mediaContext.Shows)
                    {
                        if (show.Title.ToLower() == userInputTitle.ToLower())
                        {
                            show.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Video title: ", "Video title required.\nEnter Video title: ");

                    foreach (var video in _mediaContext.Videos)
                    {
                        if (video.Title.ToLower() == userInputTitle.ToLower())
                        {
                            video.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
            }
            while (!exit);
        }

        public void WriteJson() // Write media in json format
        {
            bool exit = false;

            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("        Add New Media        ");
                Console.WriteLine("-----------------------------");

                var userInput = Input.GetIntWithPrompt("1. Add new movie\n2. Add new Show\n3. Add new Video\n\n0. Return to Main Menu\nChoose Option: ", "Please choose a valid option.");

                if (userInput == 1)
                {
                    _mediaContext.WriteMoviesJson();
                }
                else if (userInput == 2)
                {
                    _mediaContext.WriteShowsJson();
                }
                else if (userInput == 3)
                {
                    _mediaContext.WriteVideosJson();
                }
                else if (userInput == 0)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please choose a valid option.");
                }
            } while (!exit);
        } 

        public void SearchByTypeCsv() // Display all by media type CSV
        {
            bool exit = false;
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("           Display           ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Which media do you want to display?");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Return to Main Menu\nChoose Option: ", "Please enter a valid option.");
                Console.Clear();
                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesCsv();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Movies)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsCsv();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("            Shows            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Shows)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosCsv();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Videos            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Videos)
                    {
                        item.Display();
                    }
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    exit = true;
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.\n");
                    Console.Clear();
                }
            } while (!exit);
        }

        public void SearchByTitleCsv() // Display media by Title CSV file
        {
            bool exit = false;
            do
            {
                bool match = false;

                Console.WriteLine("-----------------------------");
                Console.WriteLine("           Display           ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Select Media type to search");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Return to Main Menu\nChoose Option: ", "Choose a valid option.");
                Console.Clear();

                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesCsv();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Movie title: ", "Movie title required.\nEnter Movie title: ");

                    foreach (var movie in _mediaContext.Movies)
                    {
                        if (movie.Title.ToLower() == userInputTitle.ToLower())
                        {
                            movie.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsCsv();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Show title: ", "Show title required.\nEnter Show title: ");

                    foreach (var show in _mediaContext.Shows)
                    {
                        if (show.Title.ToLower() == userInputTitle.ToLower())
                        {
                            show.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosCsv();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Video title: ", "Video title required.\nEnter Video title: ");

                    foreach (var video in _mediaContext.Videos)
                    {
                        if (video.Title.ToLower() == userInputTitle.ToLower())
                        {
                            video.Display();
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
            }
            while (!exit);
        }

        public void WriteCsv() // Write media in csv format
        {
            bool exit = false;

            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("        Add New Media        ");
                Console.WriteLine("-----------------------------");

                var userInput = Input.GetIntWithPrompt("1. Add new movie\n2. Add new Show\n3. Add new Video\n\n0. Return to Main Menu\nChoose Option: ", "Please choose a valid option.");

                if (userInput == 1)
                {
                    _mediaContext.WriteMoviesCsv();
                }
                else if (userInput == 2)
                {
                    _mediaContext.WriteShowsCsv();
                }
                else if (userInput == 3)
                {
                    _mediaContext.WriteVideosCsv();
                }
                else if (userInput == 0)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please choose a valid option.");
                }
            } while (!exit);
        }
    }
}
