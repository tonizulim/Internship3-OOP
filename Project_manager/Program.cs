using Project_manager_app.Classes;
using Project_manager_app.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var projectDictionary = new Dictionary<Project, List<ProjectTask>>
            {
            {
                new Project("projekt1", "opis1", new DateTime(2023, 10, 1), new DateTime(2023, 12, 1), Status.active),
                new List<ProjectTask>()

            }
            };

            MainMenu(projectDictionary);

        }
        static bool YNanswer()
        {
            var userInput = Console.ReadLine().ToLower();

            while (userInput != "y" && userInput != "n")
            {
                Console.Write("unesite y/n:");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput == "y")
            {
                return true;
            }

            return false;
        }

        static DateTime NewDate()
        {
            DateTime Date;
            bool correct = DateTime.TryParse(Console.ReadLine(), out Date);
            while (!correct)
            {
                Console.Write("Neispavan unos datuma, pokušajte ponovo (YYYY-MM-DD): ");
                correct = DateTime.TryParse(Console.ReadLine(), out Date);
            }
            return Date;
        }
        static int NumInput(int start, int end)
        {
            int.TryParse(Console.ReadLine(), out var userInput);
            if (start == end)
            {
                return userInput;
            }
            while (userInput < start || userInput > end)
            {
                Console.Write("Nesipravan unos! Unesi ponovno:");
                int.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;
        }

        static void MainMenu(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            var userInput = 0;

            while (userInput != 8)
            {
                Console.Clear();
                Console.WriteLine("Project manager app\nGlavni izbornik");
                Console.WriteLine("1 - Ispis svih projekata s pripadajućim zadacima\n2 - Dodavanje novog projekta\n3 - Brisanje projekta\n4 - Prikaz svih zadataka s rokom u sljedećih 7 dana\n5 - Prikaz  projekata filtriranih po status (samo aktivni, ili samo završeni, ili samo na čekanju)\n6 - Upravljanje pojedinim projektom\n7 - Upravljanje pojedinim zadatkom\n8 - Izlaz");

                userInput = NumInput(1, 8);

                switch (userInput)
                {
                    case 1:
                        foreach (var project in projectDictionary.Keys)
                        {
                            project.Print();
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        AddNewProject(projectDictionary);
                        break;
                    case 3:
                        Console.WriteLine("aaa");
                        break;
                    case 4:
                        Console.WriteLine("aaa");
                        break;
                    case 5:
                        Console.WriteLine("aaa");
                        break;
                    case 6:
                        Console.WriteLine("aaa");
                        break;
                    case 7:
                        Console.WriteLine("aaa");
                        break;
                    default:
                        break;
                }
            }
        }

        static void AddNewProject(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Dodavanje novog projekta");
            var name = ProjectNameEntry(projectDictionary);

            Console.Write("Unesite opis projekta: ");
            var description = Console.ReadLine();

            while (String.IsNullOrEmpty(description) || int.TryParse(description, out _))
            {
                Console.Write("Neispravan unos! Ponovite:");
                description = Console.ReadLine();
            }

            Console.Write("Unesi datum pocetka projekta (YYYY-MM-DD): ");
            var startDate = NewDate();

            Console.Write("Unesi datum kraja projekta (YYYY-MM-DD): ");
            var endDate = NewDate();

            while (endDate < startDate)
            {
                Console.Write("Datum kraja projekta ne moze biti prije datuma pocetka! Unesi datum (YYYY-MM-DD): ");
                endDate = NewDate();
            }

            Console.Write($"jeste li sigurni da zelite dodati projekt {name} - {description} - {startDate.ToString("yyyy-MM-dd")} - {endDate.ToString("yyyy-MM-dd")} (y/n): ");
            if (YNanswer())
            {
                Console.WriteLine("\nUspjesno dodano!");
                Project newProject = new Project(name, description, startDate, endDate, Status.pending);
                List<ProjectTask> TaskList = new List<ProjectTask>();

                projectDictionary.Add(newProject, TaskList);

            }
            else
            {
                Console.WriteLine("\nPoništeno!");
            }
            Console.WriteLine("Stisni enter za nastavak...");
            Console.ReadLine();
        }
        static string ProjectNameEntry(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Write("Unesi ime projekta: ");
            var projectName = Console.ReadLine().ToLower();

            while (String.IsNullOrEmpty(projectName) || FindProjectName(projectDictionary, projectName) || int.TryParse(projectName, out _))
            {
                Console.Write("Neispravan unos ili projekt s tim imenom vec postoji! Ponovite: ");
                projectName = Console.ReadLine().ToLower();
            }

            return projectName;
        }

        static bool FindProjectName(Dictionary<Project, List<ProjectTask>> projectDictionary, string projectName)
        {
            foreach (var project in projectDictionary.Keys)
            {
                if (project.Name == projectName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
