﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Movie_Library_Assignment.Models;
using Newtonsoft.Json;

namespace Movie_Library_Assignment.Context
{
    public class Repository
    {
        private MediaContext _mediaContext;

        public Repository(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }

        public void SearchByTypeJson() //Display all by media type
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Which media do you want to display?");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Exit\nChoose Option: ", "Please enter a valid option.");
                Console.Clear();
                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesJson();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("           Movies            ");
                    Console.WriteLine("-----------------------------");
                    foreach (var item in _mediaContext.Movies)
                    {
                        item.Display();
                    }
                    
                    exit = true;
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsJson();

                    foreach (var item in _mediaContext.Shows)
                    {
                        item.Display();
                    }

                    exit = true;
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosJson();

                    foreach (var item in _mediaContext.Videos)
                    {
                        item.Display();
                    }
                    exit = true;
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.\n");
                    Console.Clear();
                }
            } while (!exit);
        }

        public void SearchByTitleJson() //Display media by Title
        {
            bool exit = false;
            do
            {
                bool match = false;

                Console.WriteLine("Select Media type to search");
                var userInput = Input.GetIntWithPrompt("1. Movies\n2. Shows\n3. Videos\n\n0. Exit\nChoose Option: ", "Choose a valid option.");
                Console.Clear();

                if (userInput == 1) //Movies
                {
                    _mediaContext.GetMoviesJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Movie title: ", "Movie title required.\nEnter Movie title: ");
                   
                    foreach (var movie in _mediaContext.Movies)
                    {
                        if (movie.Title.ToLower() == userInputTitle.ToLower())
                        {
                            Console.WriteLine($"\n{movie}");
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter when done.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 2) //Shows
                {
                    _mediaContext.GetShowsJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Show title: ", "Show title required.\nEnter Show title: ");

                    foreach (var show in _mediaContext.Shows)
                    {
                        if (show.Title.ToLower() == userInputTitle.ToLower())
                        {
                            Console.WriteLine($"\n{show}");
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter when done.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 3) //Videos
                {
                    _mediaContext.GetVideosJson();

                    var userInputTitle = Input.GetStringWithPrompt("Enter Video title: ", "Video title required.\nEnter Video title: ");

                    foreach (var video in _mediaContext.Videos)
                    {
                        if (video.Title.ToLower() == userInputTitle.ToLower())
                        {
                            Console.WriteLine($"\n{video}");
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        Console.WriteLine("\nNo match found!");
                    }
                    Console.WriteLine("\nPress Enter when done.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == 0) //Exit
                {
                    exit = true;
                }
            }
            while (!exit);
        }
    }
}
