using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment
{
    internal class Movie
    {
        public string Title { get; set; }
        public int MovieId { get; set; }
        public List<Genre> Genres { get; set; }

        
        public Movie()
        {
            string file = $"{Environment.CurrentDirectory}\\movies.csv";
            StreamReader sr = new StreamReader(file);
            var lastId = "";
            string[] arr = null;
            sr.ReadLine();
            
            // Generate new MovieID
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                arr = line.Split(",");

                lastId = arr[0];
            }
            
            MovieId = Int32.Parse(lastId) + 1;
            Console.WriteLine($"MovieID: {MovieId}");
            sr.Close();

            bool noDuplicate = false;
            do
            {
                var getTitle = Input.GetStringWithPrompt("Enter movie title: ", "Movie title required. Enter a movie title: ");
                sr = new StreamReader(file);
                sr.ReadLine();

                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Contains('"'))
                    {
                        arr = line.Split('"');
                    }
                    else
                    {
                        arr = line.Split(',');
                    }
                    
                    
                    if (arr[1].ToLower() == getTitle.ToLower())
                    {
                        Console.WriteLine("Movie already exists!");
                        Title = "";
                        var toExit = Input.GetCharWithPrompt("Do you want to exit? Y/N", "Enter a valid option.");
                        if (toExit == 'Y')
                        {
                            noDuplicate = true;
                        }
                        break;
                    }
                }
                if (arr[1].ToLower() != getTitle.ToLower())
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
            string title = $"{Title}";
            string movieId = $"{MovieId}";
            string genres = $"";
            foreach (Genre genre in Genres) 
            {               
                genres += genre + "|";               
            }

            return $"{movieId},{title},{genres.Trim('|')}";
        }

    }

}
