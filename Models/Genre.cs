using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movie_Library_Assignment.Models
{
    public class Genre
    {
        public string Genres { get; set; }

        public override string ToString()
        {
            foreach (var item in Genres) 
            {
                Genres = item.ToString();
            }
            return Genres;
        }
    }
}
