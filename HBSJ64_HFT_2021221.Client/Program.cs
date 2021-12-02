
using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBSJ64_HFT_2021221.Client
{
    
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(7500);
            bool menu = true;
            RestService rest = new RestService("http://localhost:4472");

            while (menu)
            {
                menu = Menu();
            }
        }
        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("[1] Creating new object");
            Console.WriteLine("[2] Read an object");
            Console.WriteLine("[3] Update an existing object");
            Console.WriteLine("[4] Delete an object");
            Console.WriteLine("[5] List the items");
            Console.WriteLine("[6] Class methods");
            Console.WriteLine("[x] Close the program");
            Console.WriteLine("--------------------------------------------------");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Creating();
                    return true;
                case "2":
                    Reading();
                    return true;
                case "3":
                    Updating();
                    return true;
                case "4":
                    Deleting();
                    return true;
                case "5":
                    Listing();
                    return true;
                case "6":
                    ClassMethods();
                    return true;
                case "x":
                    return false;
                default:
                    return true;
            }
        }
        public static void Creating()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:4472");
            Console.WriteLine("What kind of object do you want to create?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            string input = Console.ReadLine();
            Console.Clear();
            if (input == "1")
            {
                Console.WriteLine("Title of the new film");
                string title = Console.ReadLine();
                Console.WriteLine("Genre of the new film");
                string genre = Console.ReadLine();
                Console.WriteLine("Reale date of the new film");
                int dateofbulish = int.Parse(Console.ReadLine());
                Console.WriteLine("ID of the actor who is played in the film");
                int acid = int.Parse(Console.ReadLine());
                Console.WriteLine("ID of the director who is directed the film");
                int diid = int.Parse(Console.ReadLine());
                rest.Post<Film>(new Film()
                {
                    Title = title,
                    Genre = genre,
                    DateOfPublish = dateofbulish,
                    ActorId = acid,
                    DirectorId = diid
                }, "film");
            }
            else if (input == "2")
            {
                Console.WriteLine("Name of the new acotr");
                string name = Console.ReadLine();
                Console.WriteLine("Age of the new actor");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Count of the new actor's awards");
                int awards = int.Parse(Console.ReadLine());
                rest.Post<Actor>(new Actor()
                {
                    Name = name,
                    Age = age,
                    Awards = awards
                }, "actor");
            }
            else if (input == "3")
            {
                Console.WriteLine("Name of the new director");
                string name = Console.ReadLine();
                Console.WriteLine("Age of the new director");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Count of the new director's awards");
                int awards = int.Parse(Console.ReadLine());
                rest.Post<Director>(new Director()
                {
                    Name = name,
                    Age = age,
                    Award = awards
                }, "director");
            }
        }
        public static void Reading()
        {
            RestService rest = new RestService("http://localhost:4472");
            Console.Clear();
            Console.WriteLine("What kind of object do you want to read?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("ID of the object: ");
            string input = Console.ReadLine();
            Console.Clear();
            if (input == "1")
            {
                var res = rest.Get<Film>("film");
                foreach (var item in res)
                {
                    if (item.FilmId == id)
                    {
                        Console.WriteLine("The title of the film: " + item.Title);
                        Console.WriteLine("The relase date of the film: " + item.DateOfPublish);
                        Console.WriteLine("The genre of the film: " + item.Genre);
                        Console.ReadKey();
                    }
                }
            }
            else if (input == "2")
            {
                var res = rest.Get<Actor>("Actor");
                foreach (var item in res)
                {
                    if (item.ActorId == id)
                    {
                        Console.WriteLine("The name of the actor: " + item.Name);
                        Console.WriteLine("The age date of the actor: " + item.Age);
                        Console.WriteLine("Awards of the actor: " + item.Awards);
                        Console.ReadKey();
                    }
                }
            }
            else if (input == "3")
            {
                var res = rest.Get<Director>("Director");
                foreach (var item in res)
                {
                    if (item.DirectorId == id)
                    {
                        Console.WriteLine("The name of the actor: " + item.Name);
                        Console.WriteLine("The age date of the actor: " + item.Age);
                        Console.WriteLine("Awards of the actor: " + item.Award);
                        Console.ReadKey();
                    }
                }
            }
        }
        public static void Updating()
        {
            
            Console.Clear();
            RestService rest = new RestService("http://localhost:4472");
            Console.WriteLine("What kind of object do you want to update?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            string input = Console.ReadLine();
            Console.Clear();
            if (input == "1")
            {
                Console.WriteLine("ID of the object");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Title of the new film");
                string title = Console.ReadLine();
                Console.WriteLine("Genre of the new film");
                string genre = Console.ReadLine();
                Console.WriteLine("Reale date of the new film");
                int dateofbulish = int.Parse(Console.ReadLine());
                Console.WriteLine("ID of the actor who is played in the film");
                int acid = int.Parse(Console.ReadLine());
                Console.WriteLine("ID of the director who is directed the film");
                int diid = int.Parse(Console.ReadLine());
                rest.Put<Film>(new Film()
                {
                    FilmId = id,
                    Title = title,
                    Genre = genre,
                    DateOfPublish = dateofbulish,
                    ActorId = acid,
                    DirectorId = diid,
                }, "film");
            }
            else if (input == "2")
            {
                Console.WriteLine("ID of the object");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Name of the new acotr");
                string name = Console.ReadLine();
                Console.WriteLine("Age of the new actor");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Count of the new actor's awards");
                int awards = int.Parse(Console.ReadLine());
                rest.Put<Actor>(new Actor()
                {
                    ActorId = id,
                    Name = name,
                    Age = age,
                    Awards = awards
                }, "actor");
            }
            else if (input == "3")
            {
                Console.WriteLine("ID of the object");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Name of the new director");
                string name = Console.ReadLine();
                Console.WriteLine("Age of the new director");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Count of the new director's awards");
                int awards = int.Parse(Console.ReadLine());
                rest.Put<Director>(new Director()
                {
                    DirectorId = id,
                    Name = name,
                    Age = age,
                    Award = awards
                }, "director");
            }

        }
        public static void Deleting()
        {
            RestService rest = new RestService("http://localhost:4472");
            Console.Clear();
            Console.WriteLine("What kind of object do you want to delete?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("ID of the item: ");
            int id = int.Parse(Console.ReadLine());
            if (input == "1")
            {
                rest.Delete(id, "film");
            }
            else if (input == "2")
            {
                rest.Delete(id, "actor");

            }
            else if (input == "3")
            {
                rest.Delete(id, "director");
            }
        }
        public static void Listing()
        {
            RestService rest = new RestService("http://localhost:4472");
            Console.Clear();
            Console.WriteLine("What kind of object do you want to list?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            string input = Console.ReadLine();
            Console.Clear();
            if (input == "1")
            {
                var films = rest.Get<Film>("film");
                foreach (var item in films)
                {
                    Console.WriteLine(item.Title + ", " + item.DateOfPublish + ", " + item.Genre);
                }
                Console.ReadKey();
            }
            else if (input == "2")
            {
                var actors = rest.Get<Actor>("actor");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.Name + ", " + item.Age + ", " + item.Awards);
                }
                Console.ReadKey();
            }
            else if (input == "3")
            {
                var directors = rest.Get<Director>("director");
                foreach (var item in directors)
                {
                    Console.WriteLine(item.Name + ", " + item.Age + ", " + item.Award);
                }
                Console.ReadKey();
            }
        }
        public static void ClassMethods()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:4472");
            Console.WriteLine("Which class's method do you you want to run?");
            Console.WriteLine("[1] Film");
            Console.WriteLine("[2] Actor");
            Console.WriteLine("[3] Director");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("Which method do you you want to run?");
                Console.WriteLine("[1] Listing the film's actors");
                Console.WriteLine("[2] Listing the film's directors");
                Console.WriteLine("[3] How many award does the actor have");
                Console.WriteLine("[4] How many award does the director have");
                string inputnd = Console.ReadLine();
                Console.Clear();
                Console.Write("ID of the item: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (inputnd == "1")
                {
                    var res = rest.Get<KeyValuePair<string, string>>("stat/FilmActors/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("A title of the film: " + item.Key + ", actors: " + item.Value);
                    }
                    Console.ReadKey();
                }
                else if (inputnd == "2")
                {
                    var res = rest.Get<KeyValuePair<string, string>>("stat/FilmDirectors/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("A title of the film: " + item.Key + ", actors: " + item.Value);
                    }
                    Console.ReadKey();
                }
                else if (inputnd == "3")
                {
                    var res = rest.Get<int>("stat/CountOfActorAwards/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("The actor has " + item + " awards");
                    }
                    
                    Console.ReadKey();
                }
                else if (inputnd == "4")
                {
                    var res = rest.Get<int>("stat/CountOfDirectorAwards/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("The director has " + item + " awards");
                    }
                    
                    Console.ReadKey();
                }
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("[1] Count of films where he/she acted on");
                string inputnd = Console.ReadLine();
                Console.Clear();
                Console.Write("ID of the item: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (inputnd == "1")
                {
                    var res = rest.Get<int>("stat/HowManyFilmDoesHeSheActedOn/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("The actor acted on " + item + " film");
                    }
                    Console.ReadKey();
                }

            }
            else if (input == "3")
            {
                Console.Clear();
                Console.WriteLine("[1] Count of films what he/she directed");
                Console.WriteLine("[2] List of directro's genres");
                string inputnd = Console.ReadLine();
                Console.Clear();
                Console.Write("ID of the item: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (inputnd == "1")
                {
                    var res = rest.Get<int>("stat/HowManyFilmDoesHeSheHave/" + id);
                    foreach (var item in res)
                    {
                        Console.WriteLine("The director directed " + item + " film");
                    }
                    Console.ReadKey();
                }
                else if (inputnd == "2")
                {
                    var res = rest.Get<KeyValuePair<int, string>>("stat/GendreOfDirectedFilms/" + id);
                    Console.WriteLine("Genres: ");
                    foreach (var item in res)
                    {
                        Console.Write(item.Value);
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
