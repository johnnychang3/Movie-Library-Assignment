using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Services.CSVFileService
{
    public class CsvFileService : IFileService
    {
        string file = $"{Environment.CurrentDirectory}\\Data\\movies.csv";
        string[] arr;
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
                while (!menuExit)
                {
                    Console.WriteLine("CSV File Media Main Menu");
                    Console.WriteLine("------------------------");

                    var userInput = Input.GetIntWithPrompt("1. Add New Media\n2. Display Media\n\n0. Exit\nChoose Option: ", "Choose a valid option.");
                    switch (userInput)
                    {
                        case 1:
                            Write();
                            break;

                        case 2:
                            Display();
                            break;
                        case 0:
                            menuExit = true;
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
                Console.WriteLine(movies[movies.Count - 1]);
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
                        Console.WriteLine(movies[movies.Count - 1]);
                        sw.WriteLine(movies[movies.Count - 1]);
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
            bool disExit = false;
            do
            {
                Console.WriteLine("\nDisplay Media Menu");
                Console.WriteLine("-------------------");
                var userInput = Input.GetIntWithPrompt("1. Display All\n0. Exit\nChoose Option: ", "Choose a valid option: ");

                sr = new StreamReader(file);
                var table = new Table();
                table.SetHeaders("MovieID", "Title", "Genres");
                sr.ReadLine();

                if (userInput == 1)
                {
                    while (!sr.EndOfStream)
                    {

                        for (int i = 0; i < 10; i++)
                        {
                            var line = sr.ReadLine();

                            if (line == null)
                            {
                                break;
                            }
                            else if (line.Contains('"'))
                            {
                                arr = line.Split('"');
                                table.AddRow($"{arr[0].Trim(',')}", arr[1], arr[2].Trim(','));
                            }
                            else
                            {
                                arr = line.Split(',');
                                table.AddRow($"{arr[0]}", arr[1], arr[2]);
                            }
                        }
                        Console.WriteLine(table.ToString());
                        table.ClearRows();
                        Console.WriteLine("Press Enter to view more, To Exit: e");
                        var exit = Console.ReadLine();
                        if (exit == "e")
                        {
                            sr.Close();
                            break;
                        }
                        else if (sr.EndOfStream)
                        {
                            Console.WriteLine("End of list.");
                            Console.ReadLine();
                            sr.Close();
                            break;
                        }
                    }
                }
                else if (userInput == 0)
                {
                    sr.Close();
                    disExit = true;
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                }
            } while (!disExit);
            Console.WriteLine("");
            sr.Close();
        }
    }
}
