using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Models
{
    public class Video : Media
    {
        public List<string> Format { get; set; }
        public int Length { get; set; }
        public List<string> Regions { get; set; }

        public override void Display()
        {
            string format = string.Join("|", Format);
            string regions = string.Join("|", Regions);

            Console.WriteLine($"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Genres:",-10}{format}\n{"Length:",-10}{Length}\n{"Regions:",-10}{regions}\n");
        }

        public override string ToString()
        {
            string format = string.Join("|", Format);
            string regions = string.Join("|", Regions);

            return $"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Genres:",-10}{format}\n{"Length:",-10}{Length}\n{"Regions:",-10}{regions}";
        }

    }
}
