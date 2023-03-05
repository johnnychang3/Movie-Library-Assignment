using Movie_Library_Assignment.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Models
{
    public class Movie : Media
    {
        public List<string> Genres { get; set; }

        public override void Display()
        {
            string genres = string.Join("|", Genres);

            Console.WriteLine($"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Genres:",-10}{genres}\n");
        }

        public override string ToString()
        {
            string genres = string.Join("|", Genres);

            return $"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Genres:",-10}{genres}";
        }
    }
}
