using Movie_Library_Assignment.Models;
using Helper;
using Newtonsoft.Json;


namespace Movie_Library_Assignment.Context
{
    public class MediaContext
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        private string _mFileJson = $"{Environment.CurrentDirectory}\\Data\\movies.json";
        private string _sFileJson = $"{Environment.CurrentDirectory}\\Data\\shows.json";
        private string _vFileJson = $"{Environment.CurrentDirectory}\\Data\\videos.json";
        private string _mFileCsv = $"{Environment.CurrentDirectory}\\Data\\movies10.csv";
        private string _sFileCsv = $"{Environment.CurrentDirectory}\\Data\\shows.csv";
        private string _vFileCsv = $"{Environment.CurrentDirectory}\\Data\\videos.csv";

        public void GetMoviesJson() // Retrieve data from movies json file
        {
            if (!File.Exists(_mFileJson))
            {
                Console.WriteLine("Movie File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_mFileJson, true);
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
            if (!File.Exists(_sFileJson))
            {
                Console.WriteLine("Show File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_sFileJson, true);
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
            if (!File.Exists(_vFileJson))
            {
                Console.WriteLine("Video File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_vFileJson, true);
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
            if (!File.Exists(_mFileCsv))
            {
                Console.WriteLine("Movie File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_mFileCsv, true);
                Movies = new List<Movie>();
                List<string> genres;
                string[] arr;
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    genres = new List<string>();
                    string idTrim;
                    string genreTrim;

                    if (line.Contains('"'))
                    {
                        arr = line.Split('"');
                        idTrim = arr[0].Trim(',');
                        genreTrim = arr[2].Trim(',');

                    }
                    else
                    {
                        arr = line.Split(',');
                        idTrim = arr[0];
                        genreTrim = arr[2];
                    }
                    int id = Convert.ToInt32(idTrim);
                    var title = arr[1];

                    foreach (var item in genreTrim.Split('|'))
                    {
                        genres.Add(item);
                    }

                    Movies.Add(new Movie { Id = id, Title = title, Genres = genres });
                    
                }
                sr.Close();
            }
        }

        public void GetShowsCsv() // Retrieve data from shows csv file
        {
            if (!File.Exists(_sFileCsv))
            {
                Console.WriteLine("Show File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_sFileCsv, true);
                Shows = new List<Show>();
                List<string> writers;
                string[] arr;
                sr.ReadLine();
                string[] arrTrim;

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    writers = new List<string>();
                    string idTrim;
                    string seasonTrim;
                    string episodeTrim;
                    string writerTrim;

                    if (line.Contains('"'))
                    {
                        arr = line.Split('"');
                        idTrim = arr[0].Trim(',');
                        arrTrim = arr[2].Split(",");
                        seasonTrim = arrTrim[1];
                        episodeTrim = arrTrim[2];
                        writerTrim = arrTrim[3];
                        
                    }
                    else
                    {
                        arr = line.Split(',');
                        idTrim = arr[0];
                        seasonTrim = arr[2];
                        episodeTrim = arr[3];
                        writerTrim = arr[4];
                    }
                    int id = Convert.ToInt32(idTrim);
                    var title = arr[1];
                    var season = Convert.ToInt32(seasonTrim);
                    var episode = Convert.ToInt32(episodeTrim);
                    var writer = writerTrim;

                    foreach (var item in writer.Split('|'))
                    {
                        writers.Add(item);
                    }

                    Shows.Add(new Show { Id = id, Title = title, Season = season, Episode = episode, Writers = writers });
                }
                sr.Close();
            }
        }

        public void GetVideosCsv() // Retrieve data from videos csv file
        {
            if (!File.Exists(_mFileCsv))
            {
                Console.WriteLine("Video File does not exist.");
            }
            else
            {
                StreamReader sr = new StreamReader(_vFileCsv, true);
                Videos = new List<Video>();
                List<string> formats;
                List<int> regions;
                string[] arr;
                string[] arrTrim;
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    formats = new List<string>();
                    regions = new List<int>();
                    string idTrim;
                    string formatTrim;
                    string lengthTrim;
                    string regionTrim;

                    var line = sr.ReadLine();

                    if (line.Contains('"'))
                    {
                        arr = line.Split('"');
                        idTrim = arr[0].Trim(',');
                        arrTrim = arr[2].Split(",");
                        formatTrim = arrTrim[1];
                        lengthTrim = arrTrim[2];
                        regionTrim = arrTrim[3];

                    }
                    else
                    {
                        arr = line.Split(',');
                        idTrim = arr[0];
                        formatTrim = arr[2];
                        lengthTrim = arr[3];
                        regionTrim = arr[4];
                    }
                    int id = Convert.ToInt32(idTrim);
                    var title = arr[1];
                    var length = Convert.ToInt32(lengthTrim);
                    var region = regionTrim;

                    foreach (var item in formatTrim.Split('|'))
                    {
                        formats.Add(item);
                    }

                    foreach (var item in region.Split('|'))
                    {
                        regions.Add(Convert.ToInt32(item));
                    }

                    Videos.Add(new Video { Id = id, Title = title, Format = formats, Length = length, Regions = regions });

                }
                sr.Close();
            }
        }

        public void WriteMoviesJson() // Write movie data in json format
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
                            Console.WriteLine("No movie added.\nPress Enter.");
                            Movies.RemoveAt(Movies.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_mFileJson, true);
                            sw.WriteLine(Movie);
                            sw.Close();
                            Console.WriteLine("\nMovie succesfully added.\nPress Enter.");
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

        public void WriteShowsJson() // Write show data in json format
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
                    List<string> writers = new List<string>();
                    bool writersExit = false;

                    do // Add writers
                    {
                        var userInputAdd = Input.GetCharWithPrompt("Add writer? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (userInputAdd.ToString().ToLower() == "y")
                        {
                            var userInput = Input.GetStringWithPrompt("Enter show writer: ", "Show writer required.\nEnter show writer: ");
                            if (userInput.Length != 0)
                            {
                                writers.Add(userInput);
                            }
                        }
                        else if (userInputAdd.ToString().ToLower() == "n")
                        {
                            if (writers.Count == 0)
                            {
                                writers.Add("(no writers listed)");
                            }
                            writersExit = true;
                        }
                    } while (!writersExit);

                    Shows.Add(new Show { Id = id, Title = title, Season = season, Episode = episode, Writers = writers });

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("            Shows            ");
                    Console.WriteLine("-----------------------------");
                    string show = JsonConvert.SerializeObject(Shows[Shows.Count - 1]);

                    Show s = JsonConvert.DeserializeObject<Show>(show);

                    string writersConcat = string.Join("|", s.Writers);
                    Console.WriteLine($"{"Id:",-10}{s.Id}\n{"Title:",-10}{s.Title}\n{"Season:",-10}{s.Season}\n{"Episode:",-10}{s.Episode}\n{"Writers:",-10}{writersConcat}");

                    do // Add show confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this Show? Y/N", "Enter a valid option: ");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("No show added.\nPress Enter.");
                            Shows.RemoveAt(Shows.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_sFileJson, true);
                            sw.WriteLine(show);
                            sw.Close();
                            Console.WriteLine("\nShow succesfully added.\nPress Enter.");
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

        public void WriteVideosJson() // Write video data in json format
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
                        if (formats.Count < 3)
                        {
                            var userInputAdd = Input.GetCharWithPrompt("Add video format? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                            if (userInputAdd.ToString().ToLower() == "y")
                            {
                                string[] formatArr = new string[] { "VHS", "DVD", "BlueRay" };

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
                        }
                        else 
                        { 
                            formExit = true; 
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
                            Console.WriteLine("No video added.\nPress Enter.");
                            Videos.RemoveAt(Videos.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_vFileJson, true);
                            sw.WriteLine(video);
                            sw.Close();
                            Console.WriteLine("\nVideo succesfully added.\nPress Enter.");
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

        public void WriteMoviesCsv() // Write movie data in csv format
        {
            GetMoviesCsv();

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

                    title = title.IndexOf(',') != -1 ? $"\"{title}\"" : title;
                  
                    Movies.Add(new Movie { Id = id, Title = title, Genres = genres });

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");

                    string genresConcat = string.Join("|", genres);
                    Console.WriteLine($"{"Id:",-10}{id}\n{"Title:",-10}{title}\n{"Genres:",-10}{genresConcat}");
                    do // Add movie confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this Movie? Y/N", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("No movie added.\nPress Enter.");
                            Movies.RemoveAt(Movies.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_mFileCsv, true);
                            sw.WriteLine($"{id},{title},{genresConcat}");
                            sw.Close();
                            Console.WriteLine("\nMovie succesfully added.\nPress Enter.");
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

        public void WriteShowsCsv() // Write show data in csv format
        {
            GetShowsCsv();

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
                    List<string> writers = new List<string>();
                    bool writersExit = false;

                    do // Add writers
                    {
                        var userInputAdd = Input.GetCharWithPrompt("Add writer? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (userInputAdd.ToString().ToLower() == "y")
                        {
                            var userInput = Input.GetStringWithPrompt("Enter show writer: ", "Show writer required.\nEnter show writer: ");
                            if (userInput.Length != 0)
                            {
                                writers.Add(userInput);
                            }
                        }
                        else if (userInputAdd.ToString().ToLower() == "n")
                        {
                            if (writers.Count == 0)
                            {
                                writers.Add("(no writers listed)");
                            }
                            writersExit = true;
                        }
                    } while (!writersExit);

                    title = title.IndexOf(',') != -1 ? $"\"{title}\"" : title;

                    Shows.Add(new Show { Id = id, Title = title, Season = season, Episode = episode, Writers = writers });

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("            Shows            ");
                    Console.WriteLine("-----------------------------");

                    string writersConcat = string.Join("|", writers);
                    Console.WriteLine($"{"Id:",-10}{id}\n{"Title:",-10}{title}\n{"Season:",-10}{season}\n{"Episode:",-10}{episode}\n{"Writers:",-10}{writersConcat}");

                    do // Add show confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this Show? Y/N", "Enter a valid option: ");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("No show added.\nPress Enter.");
                            Shows.RemoveAt(Shows.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_sFileCsv, true);
                            sw.WriteLine($"{id},{title},{season},{episode},{writersConcat}");
                            sw.Close();
                            Console.WriteLine("\nShow succesfully added.\nPress Enter.");
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

        public void WriteVideosCsv() // Write video data in csv format
        {
            GetVideosCsv();

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
                        if (formats.Count < 3)
                        {
                            var userInputAdd = Input.GetCharWithPrompt("Add video format? Y/N: ", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                            if (userInputAdd.ToString().ToLower() == "y")
                            {
                                string[] formatArr = new string[] { "VHS", "DVD", "BlueRay" };

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
                        }
                        else
                        {
                            formExit = true;
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
                    } while (!regionExit);

                    title = title.IndexOf(',') != -1 ? $"\"{title}\"" : title;

                    Videos.Add(new Video { Id = id, Title = title, Format = formats, Length = length, Regions = regions });

                    Console.Clear();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Videos            ");
                    Console.WriteLine("-----------------------------");

                    string formatsConcat = string.Join("|", formats);
                    string regionsConcat = string.Join("|", regions);

                    Console.WriteLine($"{"Id:",-10}{id}\n{"Title:",-10}{title}\n{"Format:",-10}{formatsConcat}\n{"Length:",-10}{length}\n{"Regions:",-10}{regionsConcat}");

                    do // Add video confirmation
                    {
                        var addConfirmation = Input.GetCharWithPrompt("\nAdd this video? Y/N", "Enter 'y' or 'Y' for Yes, 'n' or 'N' for No.");

                        if (addConfirmation.ToString().ToLower() == "n")
                        {
                            Console.WriteLine("No video added.\nPress Enter.");
                            Videos.RemoveAt(Videos.Count - 1);
                            exit = true;
                        }
                        else if (addConfirmation.ToString().ToLower() == "y")
                        {
                            StreamWriter sw = new StreamWriter(_vFileCsv, true);
                            sw.WriteLine($"{id},{title},{formatsConcat},{length},{regionsConcat}");
                            sw.Close();
                            Console.WriteLine("\nVideo succesfully added.\nPress Enter.");
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
