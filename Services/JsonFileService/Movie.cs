using Helper;
using Movie_Library_Assignment.Services.CSVFileService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Services.JsonFileService
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }


        public Movie()
        {
            string file = $"{Environment.CurrentDirectory}\\movies.json";
            StreamReader sr = new StreamReader(file);
            int lastId = 0;
            
            int movieId = 0;
            string title = "";

            // Generate new MovieID
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                ReadMovie m = JsonConvert.DeserializeObject<ReadMovie>(line);
                movieId = m.MovieId;
                title = m.Title;
                List<Movie> genres= m.Genres;

                lastId = movieId;
            }

            MovieId = lastId + 1;
            Console.WriteLine($"MovieID: {MovieId}");
            sr.Close();

            bool noDuplicate = false;
            do
            {
                var getTitle = Input.GetStringWithPrompt("Enter movie title: ", "Movie title required. Enter a movie title: ");
                sr = new StreamReader(file);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    ReadMovie m = JsonConvert.DeserializeObject<ReadMovie>(line);
                    movieId = m.MovieId;
                    title = m.Title;                   
                    List<Movie> genres = m.Genres;

                    if (title.ToLower() == getTitle.ToLower())
                    {
                        Console.WriteLine("Movie already exists!");
                        Title = "";
                        var toExit = Input.GetCharWithPrompt("Do you want to exit? Y/N", "Enter a valid option.");
                        if (toExit == 'Y')
                        {
                            noDuplicate = true;
                            sr.Close();
                        }
                        sr.Close();
                        break;
                    }
                }
                if (title.ToLower() != getTitle.ToLower())
                {
                    Title = getTitle;
                    Title = Title.IndexOf(',') != -1 ? $"\"{Title}\"" : Title;
                    noDuplicate = true;
                }
            } while (!noDuplicate);
            sr.Close(); 


            bool isComplete = false;
            var userInput = ' ';
            Genres = new List<Genre>();

            if (Title.Length > 0)
            {
                do
                {
                    userInput = Input.GetCharWithPrompt("Add Genre? Y/N: ", "Enter Y for yes, N for no");

                    if (userInput == 'Y')
                    {
                        Genres.Add(new Genre());
                    }
                    else if (userInput == 'N')
                    {
                        if (Genres.Count == 0)
                        {
                            Genres.Add(new Genre("(no genres listed)"));
                        }
                        isComplete = true;
                    }
                } while (!isComplete);
            }
        }

        //Methods
        public override string ToString()
        {
            string movieId = $"{MovieId}";
            string title = $"{Title}";
            string genres = $"";
            foreach (Genre genre in Genres)
            {
                genres += genre + "|";
            }

            return $"{movieId},{title},{genres.Trim('|')}";
        }
    }

    public class ReadMovie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public List<Movie> Genres { get; set; }
    }

}
