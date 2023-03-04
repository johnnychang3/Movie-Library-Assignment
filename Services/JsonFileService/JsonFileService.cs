﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Movie_Library_Assignment.Context;
using Newtonsoft.Json;

namespace Movie_Library_Assignment.Services.JsonFileService
{
    public class JsonFileService : IFileService
    {
        string file = $"{Environment.CurrentDirectory}\\Data\\movies.json";

        StreamReader sr;
        StreamWriter sw;
        List<Movie> movies = new List<Movie>();

        public void Menu()
        {
            bool menuExit = false;
            if (!File.Exists(file))
            {
                Console.WriteLine("File does not exist");
            }
            else
            {
                Console.Clear();
                while (!menuExit)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("  JSON File Media Main Menu  ");
                    Console.WriteLine("-----------------------------");

                    var userInput = Input.GetIntWithPrompt("1. Add New Media\n2. Display Media\n\n0. Exit\nChoose Option: ", "Choose a valid option.");                 
                    switch (userInput)
                    {
                        case 1:
                            Write();
                            break;

                        case 2:
                            Display();
                            Console.Clear();
                            break;
                        case 0:
                            menuExit = true;
                            Console.Clear();
                            Console.WriteLine("Good Bye!\n");
                            break;
                    }
                }
            }

        }

        public void Write()
        {
            bool exitM = false;
            Console.WriteLine("\nAdd New Media");
            Console.WriteLine("-------------\n");

            movies.Add(new Movie());

            if (movies[movies.Count - 1].Title.Length == 0)
            {
                movies.RemoveAt(movies.Count - 1);
            }
            else
            {
                string Movie = JsonConvert.SerializeObject(movies[movies.Count - 1]);
                Console.WriteLine(Movie);
                do
                {
                    var addMovConfirmation = Input.GetCharWithPrompt("Is the entry correct? Y/N", "Enter a valid option: ");

                    if (addMovConfirmation == 'N')
                    {
                        Console.WriteLine("Re-enter the movie.");
                        movies.RemoveAt(movies.Count - 1);
                        exitM = true;
                    }
                    else if (addMovConfirmation == 'Y')
                    {
                        sw = new StreamWriter(file, true);
                        Console.Write(Movie);
                        sw.WriteLine(Movie);
                        sw.Close();
                        Console.WriteLine("\nMovie succesfully added.\n");
                        exitM = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid option.");
                    }
                } while (!exitM);
            }
        }

        public void Display()
        {
            MediaContext context = new MediaContext();
            Repository repo = new Repository(context);
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("         Display Menu        ");
                Console.WriteLine("-----------------------------");
                var userInput = Input.GetIntWithPrompt("1. Display Media by Type\n2. Display Media by Title\n\n0. Exit\nChoose Option: ", "Choose a valid option: ");

                if (userInput == 1)
                {
                    Console.Clear();
                    repo.SearchByTypeJson();
                    
                    exit = true;
                }
                else if (userInput == 2)
                {
                    Console.Clear();
                    repo.SearchByTitleJson();
                }
                else if (userInput == 0)
                {
                    Console.Clear();
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Choose a valid option");
                }
            } while (!exit);
        }
    }
}