using Project_manager.Enum;
using Project_manager_app.Classes;
using Project_manager_app.Enum;
using System;
using System.Collections.Generic;

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

            },
            {
                new Project("projekt2", "opis2", new DateTime(2023, 10, 1), new DateTime(2023, 12, 1), Status.finish),
                new List<ProjectTask>()

            },
            {
                new Project("projekt3", "opis2", new DateTime(2023, 10, 1), new DateTime(2023, 12, 1), Status.pending),
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
            if (start >= end)
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
                        DeleteProject(projectDictionary);
                        break;
                    case 4:
                        Console.WriteLine("aaa");
                        break;
                    case 5:
                        PrintProjectFilterStatus(projectDictionary);
                        break;
                    case 6:
                        ProjectMenu(projectDictionary);
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

        static void DeleteProject(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Brisanje projekta\n");

            Project deleteKey = FindProject(projectDictionary);

            if (deleteKey == null)
            {
                return;
            }

            Console.Write($"Jeste li sigurni da zelite izbrisati projekt {deleteKey.Name} (y/n)? ");
            if (YNanswer())
            {

                projectDictionary.Remove(deleteKey);

                Console.WriteLine($"\nUspjesno izbrisan.");
            }
            else
            {
                Console.WriteLine("\nPoništeno!");
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();

        }

        static Project FindProject(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            PrintProjectFilter(projectDictionary, "none");

            Console.Write("\nUnesi ime projekta: ");
            var projectName = Console.ReadLine().ToLower();

            while (String.IsNullOrEmpty(projectName))
            {
                Console.Write("Neispravan unos: ");
                projectName = Console.ReadLine().ToLower();
            }

            if (!FindProjectName(projectDictionary, projectName))
            {
                Console.WriteLine($"Ne postoji projekt sa imenom: {projectName}");

                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();

                return null;
            }

            foreach (var element in projectDictionary)
            {
                if (element.Key.Name == projectName)
                {
                    return element.Key;
                }
            }
            return null;
        }

        static void PrintProjectFilterStatus(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Prikaz  projekata filtriranih po statusu: ");
            Console.WriteLine("1 - aktivan\n2 - na cekanju\n3 - zavrsen");
            
            var userInput = NumInput(1, 3);
            Console.WriteLine();


            switch (userInput)
            {
                case 1:
                    PrintProjectFilter(projectDictionary, "active");
                    break;
                case 2:
                    PrintProjectFilter(projectDictionary, "pending");
                    break;
                case 3:
                    PrintProjectFilter(projectDictionary, "finish");
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }

        static void PrintProjectFilter(Dictionary<Project, List<ProjectTask>> projectDictionary, string filter)
        {
            Console.WriteLine("naziv projekta - opis - pocetak - kraj - status");

            if (filter == "none")
            {
                foreach (var element in projectDictionary)
                {
                    element.Key.Print();
                }

                return;
            }
            foreach (var element in projectDictionary)
            {
                if (element.Key.Status.ToString() != filter)
                {
                    continue;
                }

                element.Key.Print();
            }

            return;
        }

        static void ProjectMenu(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Upravljanje pojedinim projektom\n");

            Project TargetProject = FindProject(projectDictionary);

            if (TargetProject == null)
            {
                return;
            }

            var userInput = 0;

            while (userInput != 7)
            {
                Console.Clear();
                Console.WriteLine($"Upravljanje projektom {TargetProject.Name}\n");
                Console.WriteLine("1 - Ispis svih zadataka unutar odabranog projekta\n2 - Prikaz detalja odabranog projekta\n3 - Uređivanje statusa projekta\n4 - Dodavanje zadatka unutar projekta\n5 - Brisanje zadatka iz projekta\n6 - Prikaz ukupno očekivanog vremena potrebnog za sve aktivne zadatke u projektu\n7 - Izlaz");

                userInput = NumInput(1, 7);

                switch (userInput)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        ChangeProjectStatus(TargetProject);
                        break;
                    case 4:
                        AddNewTask(projectDictionary[TargetProject], TargetProject);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }

        }

        static void ChangeProjectStatus(Project TargetProject)
        {
            Console.Clear();
            Console.WriteLine($"Uredivanje statusa projekt {TargetProject.Name}. Trenutni status projekta je: {TargetProject.Status}");

            Console.WriteLine("1 - aktivan\n2 - na cekanju\n3 - završen");
            var userInput = NumInput(1, 3);
            var newStatus = Status.active;
            switch (userInput)
            {
                case 1:
                    newStatus = Status.active;
                    break;
                case 2:
                    newStatus = Status.pending;
                    break;
                case 3:
                    newStatus = Status.finish;
                    break;
                default:
                    break;
            }

            if (newStatus == TargetProject.Status)
            {
                Console.WriteLine("Status ostaje isti.");
                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();

                return;
            }

            Console.Write($"jeste li sigurni da zelite promjeniti status iz {TargetProject.Status} u {newStatus} (y/n): ");
            if (YNanswer())
            {
                TargetProject.Status = newStatus;
                Console.WriteLine("\nStatus uspjesno promjenjen!");
            }
            else
            {
                Console.WriteLine("\nPonisteno!");
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }

        static void AddNewTask(List<ProjectTask> taskList, Project targetProject)
        {
            Console.Clear();
            Console.WriteLine($"Dodavanje novog zadataka u projekt {targetProject.Name}\n");
            var name = TaskNameEntry(taskList);

            Console.Write("Unesite opis zadatka: ");
            var description = Console.ReadLine();

            while (String.IsNullOrEmpty(description) || int.TryParse(description, out _))
            {
                Console.Write("Neispravan unos! Ponovite:");
                description = Console.ReadLine();
            }

            Console.Write("Unesi rok za izvrsenje (YYYY-MM-DD): ");
            var endDate = NewDate();
            while (endDate < DateTime.Now)
            {
                Console.Write("rok za izvrsenje ne moze biti iz prošlosti! unos: (YYYY-MM-DD): ");
                endDate = NewDate();
            }
            Console.WriteLine("Odaberi status zadataka");
            var status = InputTaskStatus();

            Console.WriteLine("Odaberi prioritet zadataka");
            var priority = InputTaskPriority();

            Console.Write("Unesi ocekivano vrijeme trajanja (u minutama)");

            var duration = NumInput(1, 1);
            while (duration <= 0)
            {
                Console.Write("ocekivano vrijeme ne moze biti manje od 0! unos:");
                duration = NumInput(1, 1);
            }


            Console.Write($"jeste li sigurni da zelite dodati zadatak: {name} - {description} - {endDate.ToString("yyyy-MM-dd")} - {priority} - {duration}min - {targetProject.Name} (y/n): ");
            if (YNanswer())
            {
                Console.WriteLine("\nUspjesno dodano!");
                ProjectTask newTask = new ProjectTask(name, description, endDate, status, priority, duration, targetProject.Name);

                taskList.Add(newTask);
            }
            else
            {
                Console.WriteLine("\nPoništeno!");
            }
            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }

        static StatusTask InputTaskStatus()
        {
            Console.WriteLine("1 - aktivan\n2 - odgoden\n3 - završen");

            var userInput = NumInput(1, 3);

            var newStatus = StatusTask.active;
            switch (userInput)
            {
                case 1:
                    newStatus = StatusTask.active;
                    break;
                case 2:
                    newStatus = StatusTask.delayed;
                    break;
                case 3:
                    newStatus = StatusTask.finish;
                    break;
                default:
                    break;
            }

            return newStatus;
        }

        static TaskPriority InputTaskPriority()
        {
            Console.WriteLine($"1 - visoki\n2 - srednji\n3 - niski");

            var userInput = NumInput(1, 3);

            var newPriority = TaskPriority.high;
            switch (userInput)
            {
                case 1:
                    newPriority = TaskPriority.high;
                    break;
                case 2:
                    newPriority = TaskPriority.medium;
                    break;
                case 3:
                    newPriority = TaskPriority.low;
                    break;
                default:
                    break;
            }

            return newPriority;
        }
        static string TaskNameEntry(List<ProjectTask> taskList)
        {
            Console.Write("Unesi ime zadatka: ");
            var taskName = Console.ReadLine().ToLower();

            while (String.IsNullOrEmpty(taskName) || FindTaskName(taskList, taskName) || int.TryParse(taskName, out _))
            {
                Console.Write("Neispravan unos ili zadatak s tim imenom vec postoji! Ponovite: ");
                taskName = Console.ReadLine().ToLower();
            }

            return taskName;
        }
        static bool FindTaskName(List<ProjectTask> taskList, string taskName)
        {
            foreach (var project in taskList)
            {
                if (project.Name == taskName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
