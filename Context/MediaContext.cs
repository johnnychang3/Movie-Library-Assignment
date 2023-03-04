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

        public void GetMoviesCsv()
        {

        }

        public void GetShowsCsv()
        {

        }

        public void GetVideosCsv()
        {

        }

        public void WriteMoviesJson() //Write movies in json format
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

                var userInputTitle = Input.GetStringWithPrompt("Enter movie title: ", "Movie title required. Enter a movie title: ");

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

                if (!match)
                {
                    int id = Movies.Count + 1;
                    var title = userInputTitle;
                    List<string> genres = new List<string>();
                    do
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

                            userInput = Input.GetIntWithPrompt("\nSelect genre to add: ", "Enter a valid option: ");
                            if (userInput <= genreOptions.Length)
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
                    } while (!exit);

                    Movies.Add(new Movie { Id = id, Title = title, Genres = genres });
                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");
                    string Movie = JsonConvert.SerializeObject(Movies[Movies.Count - 1]);

                    Movie m = JsonConvert.DeserializeObject<Movie>(Movie);
                    string genresConcat = string.Join("|", m.Genres);
                    Console.WriteLine($"{"Id:",-10}{m.Id}\n{"Title:",-10 }{m.Title}\n{"Genres:",-10}{genresConcat}");
                    do
                    {
                        var addMovConfirmation = Input.GetCharWithPrompt("\nAdd this Movie? Y/N", "Enter a valid option: ");

                        if (addMovConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("Re-enter the movie.");
                            Movies.RemoveAt(Movies.Count - 1);
                            exit = true;
                        }
                        else if (addMovConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_mFile, true);
                            sw.WriteLine(Movie);
                            sw.Close();
                            Console.WriteLine("\nMovie succesfully added.\n");
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
    }
}
