using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Library_Assignment.Models;
using Helper;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Movie_Library_Assignment.Context
{
    public class MediaContext
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        private string _mFile = $"{Environment.CurrentDirectory}\\Data\\movies.json";
        private string _sFile = $"{Environment.CurrentDirectory}\\Data\\shows.json";
        private string _vFile = $"{Environment.CurrentDirectory}\\Data\\videos.json";

        public void GetMoviesJson() // Retrieve data from movies json file
        {
            if (!File.Exists(_mFile))
            {
                Console.WriteLine("Movie File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_mFile, true);
                Movies = new List<Movie>();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    Movie m = JsonConvert.DeserializeObject<Movie>(line);
                    Movies.Add(m);
                }
                sr.Close();
            }
        }

        public void GetShowsJson() // Retrieve data from shows json file
        {
            if (!File.Exists(_sFile))
            {
                Console.WriteLine("Show File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_sFile, true);
                Shows = new List<Show>();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    Show s = JsonConvert.DeserializeObject<Show>(line);
                    Shows.Add(s);
                }
                sr.Close();
            }
        }

        public void GetVideosJson() // Retrieve data from videos json file
        {
            if (!File.Exists(_vFile))
            {
                Console.WriteLine("Video File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_vFile, true);
                Videos = new List<Video>();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    Video v = JsonConvert.DeserializeObject<Video>(line);
                    Videos.Add(v);
                }
                sr.Close();
            }
        }

        public void GetMoviesCsv() // Retrieve data from movies csv file
        {

        }

        public void GetShowsCsv() // Retrieve data from shows csv file
        {

        }

        public void GetVideosCsv() // Retrieve data from videos csv file
        {

        }

        public void WriteMoviesJson() // Write movies data in json format
        {
            GetMoviesJson();

            bool exit = false;

            do
            {
                bool match = false;
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("           Movies            ");
                Console.WriteLine("-----------------------------");

                var userInputTitle = Input.GetStringWithPrompt("Enter movie title: ", "Movie title required.\nEnter a movie title: ");

                foreach (var movie in Movies)
                {
                    if (movie.Title.ToLower() == userInputTitle.ToLower())
                    {
                        Console.WriteLine($"\nMovie already exist!");
                        var toExit = Input.GetCharWithPrompt("Do you want to exit? Y/N", "Enter a valid option.");

                        if (toExit.ToString().ToLower() == "y")
                        {
                            exit = true;
                            userInputTitle = "";
                        }
                        else if (toExit.ToString().ToLower() != "n")
                        {
                            Console.WriteLine("Enter a valid option.");
                        }
                        match = true;
                    }
                }

                if (!match) // If no match
                {
                    int id = Movies.Count + 1;
                    var title = userInputTitle;
                    List<string> genres = new List<string>();
                    do // Add genres
                    {
                        var userInputAdd = Input.GetCharWithPrompt("Add Genre? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (userInputAdd.ToString().ToLower() == "y")
                        {
                            string[] genreOptions = new string[]
                            {
                            "Action",
                            "Adventure",
                            "Animation",
                            "Children",
                            "Comedy",
                            "Crime",
                            "Documentary",
                            "Drama",
                            "Fantasy",
                            "Film-Noir",
                            "Horror",
                            "IMAX",
                            "Musical",
                            "Mystery",
                            "Romance",
                            "Sci-Fi",
                            "Thriller",
                            "War",
                            "Western"
                            };

                            var userInput = 0;
                            Console.Clear();
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("           Genres            ");
                            Console.WriteLine("-----------------------------");
                            for (int i = 1; i < genreOptions.Length; i++)
                            {
                                Console.Write("{0,3} {1,1} {2,-15}", i, "-", genreOptions[i - 1]);

                                if (i - 0.5 > genreOptions.Length / 2)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\t{0,0} {1,1} {2,-15}", i + 10, "-", genreOptions[i + 9]);
                                    i -= 1;
                                    i++;
                                }
                            }

                            userInput = Input.GetIntWithPrompt("\nSelect genre to add: ", "Enter a valid option.");
                            if (userInput <= genreOptions.Length && userInput != 0)
                            {
                                genres.Add(genreOptions[userInput - 1].ToString());
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option.");
                            }
                        }
                        else if (userInputAdd.ToString().ToLower() == "n")
                        {
                            if (genres.Count == 0)
                            {
                                genres.Add("(no genres listed)");
                            }
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }
                    } while (!exit);

                    Movies.Add(new Movie { Id = id, Title = title, Genres = genres });
                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");
                    string Movie = JsonConvert.SerializeObject(Movies[Movies.Count - 1]);

                    Movie m = JsonConvert.DeserializeObject<Movie>(Movie);
                    string genresConcat = string.Join("|", m.Genres);
                    Console.WriteLine($"{"Id:",-10}{m.Id}\n{"Title:",-10}{m.Title}\n{"Genres:",-10}{genresConcat}");
                    do // Add movie confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this Movie? Y/N", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("Re-enter the movie.");
                            Movies.RemoveAt(Movies.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_mFile, true);
                            sw.WriteLine(Movie);
                            sw.Close();
                            Console.WriteLine("\nMovie succesfully added.\n");
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }
                        Console.ReadLine();
                        Console.Clear();
                    } while (!exit);
                }
            } while (!exit);
        }

        public void WriteShowsJson() // Write shows data in json format
        {
            GetShowsJson();

            bool exit = false;

            do
            {
                bool match = false;

                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("            Shows            ");
                Console.WriteLine("-----------------------------");

                var userInputTitle = Input.GetStringWithPrompt("Enter show title: ", "Show title required.\nEnter show title: ");
                var userInputSeason = Input.GetIntWithPrompt("Enter show season: ", "Show season required.");
                var userInputEpisode = Input.GetIntWithPrompt("Enter show episode: ", "Show episode required.");
                var userInputWriter = Input.GetStringWithPrompt("Enter show writer: ", "Show writer required.\nEnter show writer: ");

                foreach (var show in Shows)
                {
                    if (show.Title.ToLower() == userInputTitle.ToLower() && show.Season == userInputSeason && show.Episode == userInputEpisode) // If match
                    {
                        Console.WriteLine($"\nShow already exist!");
                        var toExit = Input.GetCharWithPrompt("Do you want to exit? Y/N", "Enter a valid option.");

                        if (toExit.ToString().ToLower() == "y")
                        {
                            exit = true;
                            Console.Clear();
                        }
                        else if (toExit.ToString().ToLower() != "n")
                        {
                            Console.WriteLine("Enter a valid option.");
                        }
                        match = true;
                    }
                }

                if (!match) // If no match add movie
                {
                    int id = Shows.Count + 1;
                    var title = userInputTitle;
                    var season = userInputSeason;
                    var episode = userInputEpisode;
                    var writer = userInputWriter;

                    Shows.Add(new Show { Id = id, Title = title, Season = season, Episode = episode, Writer = writer });

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("            Shows            ");
                    Console.WriteLine("-----------------------------");
                    string show = JsonConvert.SerializeObject(Shows[Shows.Count - 1]);

                    Show s = JsonConvert.DeserializeObject<Show>(show);

                    Console.WriteLine($"{"Id:",-10}{s.Id}\n{"Title:",-10}{s.Title}\n{"Season:",-10}{s.Season}\n{"Episode:",-10}{s.Episode}\n{"Writer:",-10}{s.Writer}");

                    do // Add show confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this Show? Y/N", "Enter a valid option: ");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("Re-enter the show.");
                            Shows.RemoveAt(Shows.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_sFile, true);
                            sw.WriteLine(show);
                            sw.Close();
                            Console.WriteLine("\nShow succesfully added.\n");
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid option.");
                        }
                        Console.ReadLine();
                        Console.Clear();
                    } while (!exit);
                }
            } while (!exit);
        }
        public void WriteVideosJson() // Write videos data in json format
        {
            GetVideosJson();

            bool exit = false;

            do
            {
                bool match = false;

                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("            Videos            ");
                Console.WriteLine("-----------------------------");

                var userInputTitle = Input.GetStringWithPrompt("Enter video title: ", "Video title required.\nEnter a video title: ");

                foreach (var video in Videos)
                {
                    if (video.Title.ToLower() == userInputTitle.ToLower()) // If match
                    {
                        Console.WriteLine($"\nVideo already exist!");
                        var toExit = Input.GetCharWithPrompt("Do you want to exit? Y/N", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (toExit.ToString().ToLower() == "y")
                        {
                            exit = true;
                            Console.Clear();
                        }
                        else if (toExit.ToString().ToLower() != "n")
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }
                        match = true;
                    }
                }

                if (!match) // If no match add movie
                {
                    int id = Videos.Count + 1;
                    var title = userInputTitle;
                    List<string> formats = new List<string>();
                    List<int> regions = new List<int>();

                    var length = Input.GetIntWithPrompt("Enter video length: ", "Video length required.");

                    bool formExit = false;
                    do // Add video formats
                    {                        
                        var userInputAdd = Input.GetCharWithPrompt("Add video format? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (userInputAdd.ToString().ToLower() == "y")
                        {
                            string[] formatArr = new string[] {"VHS", "DVD", "BlueRay"};

                            Console.Clear();
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("           Formats           ");
                            Console.WriteLine("-----------------------------");

                            Console.WriteLine($"1. {formatArr[0]}\n2. {formatArr[1]}\n3. {formatArr[2]}\n");

                            var userInput = Input.GetIntWithPrompt("Select format to add: ", "Enter a valid option.");
                            if (userInput <= formatArr.Length && userInput != 0)
                            {
                                formats.Add(formatArr[userInput - 1].ToString());
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option.");
                            }

                        }
                        else if (userInputAdd.ToString().ToLower() == "n")
                        {
                            if (formats.Count == 0)
                            {
                                formats.Add("(no formats listed)");
                            }
                            formExit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }

                    } while (!formExit);

                    bool regionExit = false;
                    do // Add video regions
                    {
                        var userInputAdd = Input.GetCharWithPrompt("Add Region? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (userInputAdd.ToString().ToLower() == "y")
                        {
                            string[] regionArr = new string[]
                            {
                                "Region 0 - All",
                                "Region 1 - Canada, the United States and U.S. territories",
                                "Region 2 - Japan, Europe, South Africa, the Middle East (including Egypt) and Greenland",
                                "Region 3 - Southeast Asia, and East Asia (including Hong Kong)",
                                "Region 4 - Australia, New Zealand, the Pacific Islands, Central America, Mexico, South America, and the Caribbean",
                                "Region 5 - Eastern Europe, Russia, the Indian Subcontinent, Africa, North Korea, and Mongolia",
                                "Region 6 - China",
                                "Region 7 - reserved for unspecified special use",
                                "Region 8 - Special international venues for air and oceanic travel"
                            };
                            Console.Clear();
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("           Regions            ");
                            Console.WriteLine("-----------------------------");

                            foreach (var item in regionArr)
                            {
                                Console.WriteLine(item);
                            }
                            var userInput = Input.GetIntWithPrompt("Select region to add(0-8): ", "Enter a valid option.");
                            if (userInput <= regionArr.Length)
                            {
                                regions.Add(userInput);
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option.");
                            }
                        }
                        else if (userInputAdd.ToString().ToLower() == "n")
                        {
                            regionExit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }
                    } while(!regionExit);

                    Videos.Add(new Video { Id = id, Title = title, Format = formats, Length = length, Regions = regions});

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Videos            ");
                    Console.WriteLine("-----------------------------");
                    string video = JsonConvert.SerializeObject(Videos[Videos.Count - 1]);

                    Video v = JsonConvert.DeserializeObject<Video>(video);
                    string formatsConcat = string.Join("|", v.Format);
                    string regionsConcat = string.Join("|", v.Regions);

                    Console.WriteLine($"{"Id:",-10}{v.Id}\n{"Title:",-10}{v.Title}\n{"Format:",-10}{formatsConcat}\n{"Length:",-10}{v.Length}\n{"Regions:",-10}{regionsConcat}");

                    do // Add video confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this video? Y/N", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("Re-enter the video.");
                            Videos.RemoveAt(Videos.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_vFile, true);
                            sw.WriteLine(video);
                            sw.Close();
                            Console.WriteLine("\nVideo succesfully added.\n");
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");
                        }
                        Console.ReadLine();
                        Console.Clear();
                    } while (!exit);
                }
            } while (!exit);
        }
    }
}
