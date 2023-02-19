using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment
{
    internal class Genre
    {
        public string Name { get; set; }

        public Genre()
        {

            string[] genres = new string[]
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

            for (int i = 1; i < genres.Length; i++)
            {
                Console.Write("{0,3} {1,1} {2,-15}", i, "-", genres[i - 1]);

                if (i - 0.5 > genres.Length / 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t{0,0} {1,1} {2,-15}", i + 10, "-", genres[i + 9]);
                    i -= 1;
                    i++;
                }
            }

            userInput = Input.GetIntWithPrompt("\nSelect genre to add: ", "Enter a valid option: ");

            Name = genres[userInput - 1].ToString();
        }

        public Genre(string name)
        {
            Name = name;
        }

        //Methods
        public override string ToString()
        {
            return Name;
        }
    }
}


    


