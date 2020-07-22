using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DB4_Movies
{
    class MovieApp
    {
        private List<Movie> movies;
        private Dictionary<int, string> menu;

        public void Run()
        {
            movies = new List<Movie>();
            menu = new Dictionary<int, string>();

            GetData();

            do
            {
                Console.Clear();
                DisplayMenu();
                DisplayCategory(Console.ReadLine());
            } while (AnotherCategory());
        }

        private void DisplayMenu()
        {
            //if there is nothing in the menu, there are no movies, exit the app.
            if(menu.Count == 0)
            {
                Console.WriteLine("Something went wrong, there are no movies!");
                Console.WriteLine("System will now exit.");
                Thread.CurrentThread.Abort();
            }

            //initial displays.
            Console.WriteLine("Welcome to the Movie List Application!\n");
            Console.WriteLine($"There are {movies.Count} movies in this list.");
            Console.WriteLine("There fall in the following categories:");

            //display the menu.
            foreach(KeyValuePair<int, string> item in menu)
            {
                Console.WriteLine($"{item.Key,2} {item.Value}");
            }

            Console.Write("\nWhat category are you interested in? ");
        }

        private void DisplayCategory(string category)
        {
            //see if they entered the category number
            if (int.TryParse(category, out int key))
            {
                try
                { //try to get the category based on the number
                    category = menu[key];
                }
                catch
                { //number is invalid so set category to null.
                    category = null;
                }
            }

            //see if the user entered the category in a different case, and correct it.
            foreach(KeyValuePair<int, string> item in menu)
            {
                if(category != null && category.Equals(item.Value, StringComparison.OrdinalIgnoreCase))
                {
                    category = item.Value;
                    break;
                }
            }

            //clear the screen
            Console.Clear();
            List<Movie> thisCategory = new List<Movie>();

            //pull out movies in this category
            foreach(Movie mov in movies)
            {
                if (mov.Category == category)
                {
                    thisCategory.Add(mov);
                }
            }

            //sort the movies
            thisCategory.Sort();

            //if there are no movies to display, write that the category was invalid
            if(thisCategory.Count == 0)
            {
                Console.WriteLine("Invalid Category");
            }
            else
            { //otherwise display the movies
                Console.WriteLine($"The movies in the category {category} are:\n");
                foreach(Movie mov in thisCategory)
                {
                    Console.WriteLine(mov);
                }
            }
        }

        private bool AnotherCategory()
        {
            Console.Write("\nWould you like to review another category? (y/n): ");
            ConsoleKey choice = Console.ReadKey().Key;
            if(choice == ConsoleKey.Y)
            {
                return true;
            }
            else if (choice == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return AnotherCategory();
            }
        }

        private void GetData()
        {
            //initialize variables
            int menuNumber = 1;
            List<string> cat = new List<string>();

            //create movies, adding them to the list.
            movies.Add(new Movie("Star Wars", "SciFi"));
            movies.Add(new Movie("Serenity", "SciFi"));
            movies.Add(new Movie("Up", "Animated"));
            movies.Add(new Movie("Howl's Moving Castle", "Animated"));
            movies.Add(new Movie("Trolls", "Animated"));
            movies.Add(new Movie("Ready Player One", "SciFi"));
            movies.Add(new Movie("Spider-Man into the Spider-Verse", "Animated"));
            movies.Add(new Movie("Bird Box", "Horror"));
            movies.Add(new Movie("The Nun", "Horror"));
            movies.Add(new Movie("Get Out", "Horror"));
            movies.Add(new Movie("Alien", "SciFi"));
            movies.Add(new Movie("Predator", "SciFi"));
            movies.Add(new Movie("John Wick", "Action"));
            movies.Add(new Movie("Mission Impossible", "Action"));
            movies.Add(new Movie("Golden Eye", "Action"));
            movies.Add(new Movie("This Means War", "Spy"));
            movies.Add(new Movie("Skyfall", "Spy"));
            movies.Add(new Movie("The Bourne Identity", "Spy"));
            movies.Add(new Movie("Joker", "Thriller"));
            movies.Add(new Movie("Fantasy Island", "Thriller"));

            //determine the menu based on the movies that are added.
            foreach(Movie mov in movies)
            {
                if(!cat.Contains(mov.Category))
                {
                    cat.Add(mov.Category);
                    menu.Add(menuNumber, mov.Category);
                    menuNumber++;
                }
            }
        }
    }
}
