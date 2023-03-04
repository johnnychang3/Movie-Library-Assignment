using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Library_Assignment.Models;
using Helper;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

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
                StreamReader sr = new StreamReader(_mFile);
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
                StreamReader sr = new StreamReader(_sFile);
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
                StreamReader sr = new StreamReader(_vFile);
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
    }
}
