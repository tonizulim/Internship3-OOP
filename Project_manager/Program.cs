using Project_manager.Enum;
using Project_manager_app.Classes;
using Project_manager_app.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Project_manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var projectDictionary = new Dictionary<Project, List<ProjectTask>>
            {
                {
                    new Project("project1", "Description for Project 1", new DateTime(2023, 10, 1), new DateTime(2024, 12, 1), Status.active),
                    new List<ProjectTask>
                    {
                        new ProjectTask("task1", "Description for Task 1", new DateTime(2023, 10, 5), StatusTask.delayed, TaskPriority.low, 3, "project1"),
                        new ProjectTask("task2", "Description for Task 2", new DateTime(2023, 10, 15), StatusTask.finish, TaskPriority.high, 5, "project1"),
                        new ProjectTask("task3", "Description for Task 3", new DateTime(2024, 11, 19), StatusTask.active, TaskPriority.low, 7, "project1"),
                        new ProjectTask("task4", "Description for Task 4", new DateTime(2024, 11, 14), StatusTask.delayed, TaskPriority.medium, 2, "project1"),
                        new ProjectTask("task5", "Description for Task 5", new DateTime(2024, 11, 20), StatusTask.active, TaskPriority.medium, 4, "project1"),
                        new ProjectTask("task6", "Description for Task 6", new DateTime(2023, 11, 20), StatusTask.active, TaskPriority.low, 6, "project1")
                    }
                },
                {
                    new Project("project2", "Description for Project 2", new DateTime(2023, 9, 15), new DateTime(2023, 11, 30), Status.active),
                    new List<ProjectTask>
                    {
                        new ProjectTask("task0", "Description for Task 3", new DateTime(2024, 11, 19), StatusTask.active, TaskPriority.low, 7, "project2"),
                        new ProjectTask("task1", "Description for Task 1", new DateTime(2023, 9, 20), StatusTask.finish, TaskPriority.medium, 4, "project2"),
                        new ProjectTask("task2", "Description for Task 2", new DateTime(2023, 9, 30), StatusTask.finish, TaskPriority.high, 3, "project2"),
                        new ProjectTask("task3", "Description for Task 3", new DateTime(2023, 10, 10), StatusTask.finish, TaskPriority.medium, 5, "project2"),
                        new ProjectTask("task4", "Description for Task 4", new DateTime(2023, 10, 25), StatusTask.finish, TaskPriority.low, 6, "project2"),
                        new ProjectTask("task5", "Description for Task 5", new DateTime(2023, 11, 5), StatusTask.finish, TaskPriority.high, 7, "project2"),
                        new ProjectTask("task6", "Description for Task 6", new DateTime(2023, 11, 20), StatusTask.finish, TaskPriority.medium, 2, "project2")
                    }
                },
                {
                new Project("project3", "Description for Project 3", new DateTime(2023, 8, 1), new DateTime(2023, 10, 15), Status.finish),
                    new List<ProjectTask>
                    {
                        new ProjectTask("task1", "Description for Task 1", new DateTime(2023, 8, 5), StatusTask.finish, TaskPriority.high, 3, "project3"),
                        new ProjectTask("task2", "Description for Task 2", new DateTime(2024, 11, 15), StatusTask.active, TaskPriority.medium, 4, "project3"),
                        new ProjectTask("task3", "Description for Task 3", new DateTime(2024, 11, 20), StatusTask.delayed, TaskPriority.low, 6, "project3"),
                        new ProjectTask("task4", "Description for Task 4", new DateTime(2023, 9, 15), StatusTask.finish, TaskPriority.high, 5, "project3"),
                        new ProjectTask("task5", "Description for Task 5", new DateTime(2024, 11, 25), StatusTask.active, TaskPriority.high, 2, "project3"),
                        new ProjectTask("task6", "Description for Task 6", new DateTime(2023, 10, 5), StatusTask.finish, TaskPriority.medium, 7, "project3")
                    }
                },
                {
                new Project("project4", "Description for Project 4", new DateTime(2023, 7, 10), new DateTime(2023, 9, 30), Status.active),
                    new List<ProjectTask>
                    {
                        new ProjectTask("task 1", "Description for Task 1", new DateTime(2023, 7, 15), StatusTask.finish, TaskPriority.high, 5, "project4"),
                        new ProjectTask("task2", "Description for Task 2", new DateTime(2023, 7, 25), StatusTask.finish, TaskPriority.medium, 4, "project4"),
                        new ProjectTask("task3", "Description for Task 3", new DateTime(2023, 8, 10), StatusTask.finish, TaskPriority.medium, 3, "project4"),
                        new ProjectTask("task4", "Description for Task 4", new DateTime(2023, 8, 25), StatusTask.finish, TaskPriority.low, 6, "project4"),
                        new ProjectTask("task5", "Description for Task 5", new DateTime(2023, 9, 5), StatusTask.finish, TaskPriority.high, 7, "project4"),
                        new ProjectTask("task6", "Description for Task 6", new DateTime(2023, 9, 20), StatusTask.finish, TaskPriority.medium, 2, "project4")
                    }
                },
                {
                new Project("project5", "Description for Project 5", new DateTime(2025, 6, 20), new DateTime(2026, 8, 31), Status.active),
                    new List<ProjectTask>
                    {
                        new ProjectTask("task1", "Description for Task 1", new DateTime(2023, 6, 25), StatusTask.finish, TaskPriority.medium, 3, "project5"),
                        new ProjectTask("task2", "Description for Task 2", new DateTime(2024, 11, 22), StatusTask.active, TaskPriority.medium, 5, "project5"),
                        new ProjectTask("task3", "Description for Task 3", new DateTime(2023, 7, 15), StatusTask.finish, TaskPriority.low, 4, "project5"),
                        new ProjectTask("task4", "Description for Task 4", new DateTime(2023, 7, 25), StatusTask.finish, TaskPriority.medium, 6, "project5"),
                        new ProjectTask("task5", "Description for Task 5", new DateTime(2023, 8, 10), StatusTask.finish, TaskPriority.high, 7, "project5"),
                        new ProjectTask("task6", "Description for Task 6", new DateTime(2023, 8, 20), StatusTask.finish, TaskPriority.low, 2, "project5")
                    }
                }
            };


            MainMenu(projectDictionary);

        }

        static bool IsProjectFinished(Project TargetProject)
        {
            if (TargetProject.Status != Status.finish)
            {
                return false;

            }
            Console.WriteLine("Projekt je oznacen kao 'finish' promjene na njemu nisu moguce.");
            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
            return true;
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
                        PrintProjectTask(projectDictionary);
                        break;
                    case 2:
                        AddNewProject(projectDictionary);
                        break;
                    case 3:
                        DeleteProject(projectDictionary);
                        break;
                    case 4:
                        PrintAllTaskEnding(projectDictionary);
                        break;
                    case 5:
                        PrintProjectFilterStatus(projectDictionary);
                        break;
                    case 6:
                        ProjectMenu(projectDictionary);
                        break;
                    case 7:
                        TaskMenu(projectDictionary);
                        break;
                    default:
                        break;
                }
            }
        }

        static void PrintProjectTask(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Ispis svih projekata s pripadajućim zadacima");

            Console.WriteLine("\nnaziv projekta");
            Console.WriteLine("     naziv zadatka");

            foreach (var element in projectDictionary)
            {
                Console.WriteLine();
                Console.WriteLine(element.Key.Name);
                foreach (var tasks in element.Value)
                {
                    Console.Write("    ");
                    Console.WriteLine(tasks.Name);
                }
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
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

            DateTime minEndDate = startDate < DateTime.Now ? DateTime.Now : startDate;
            while (endDate < minEndDate)
            {
                Console.Write($"Datum kraja projekta mora biti nakon {minEndDate.ToString("yyyy-MM-dd")}! Unesi datum (YYYY-MM-DD): ");
                endDate = NewDate();
            }

            Status status = startDate < DateTime.Now ? Status.active : Status.pending;

            Console.Write($"jeste li sigurni da zelite dodati projekt {name} - {description} - {startDate.ToString("yyyy-MM-dd")} - {endDate.ToString("yyyy-MM-dd")} (y/n): ");
            if (YNanswer())
            {
                Console.WriteLine("\nUspjesno dodano!");
                Project newProject = new Project(name, description, startDate, endDate, status);
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

        static void PrintAllTaskEnding(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Prikaz svih zadataka s rokom u sljedećih 7 dana");

            Console.WriteLine("\nNaziv zadatka - naziv projekta\n");

            foreach (var element in projectDictionary)
            {
                if (element.Key.Status == Status.finish)
                {
                    continue;
                }

                foreach (var tasks in element.Value)
                {
                    if ((tasks.EndDate - DateTime.Now).TotalDays > 7 || tasks.EndDate < DateTime.Now || tasks.Status == StatusTask.finish)
                    {
                        continue;
                    }
                    Console.WriteLine($"{tasks.Name} - {element.Key.Name}");
                }
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
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
            Console.WriteLine("naziv projekta");

            if (filter == "none")
            {
                foreach (var element in projectDictionary)
                {
                    Console.WriteLine(element.Key.Name);
                }

                return;
            }
            foreach (var element in projectDictionary)
            {
                if (element.Key.Status.ToString() != filter)
                {
                    continue;
                }

                Console.WriteLine(element.Key.Name);
            }

            return;
        }

        static void ProjectMenu(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Upravljanje pojedinim projektom\n");

            Project targetProject = FindProject(projectDictionary);

            if (targetProject == null)
            {
                return;
            }

            var userInput = 0;

            while (userInput != 7)
            {
                Console.Clear();
                Console.WriteLine($"Upravljanje projektom {targetProject.Name}\n");
                Console.WriteLine("1 - Ispis svih zadataka unutar odabranog projekta\n2 - Prikaz detalja odabranog projekta\n3 - Uređivanje statusa projekta\n4 - Dodavanje zadatka unutar projekta\n5 - Brisanje zadatka iz projekta\n6 - Prikaz ukupno očekivanog vremena potrebnog za sve aktivne zadatke u projektu\n7 - Izlaz");

                userInput = NumInput(1, 7);

                switch (userInput)
                {
                    case 1:
                        PrintAllTaskInProject(projectDictionary[targetProject], targetProject);
                        break;
                    case 2:
                        ShowProjectDetails(targetProject);
                        break;
                    case 3:
                        if (IsProjectFinished(targetProject))
                        {
                            break;
                        }
                        ChangeProjectStatus(targetProject);
                        break;
                    case 4:
                        if (IsProjectFinished(targetProject))
                        {
                            break;
                        }
                        AddNewTask(projectDictionary[targetProject], targetProject);

                        if (IsAllTaskFinish(projectDictionary, targetProject))
                        {
                            targetProject.Status = Status.finish;
                        }

                        break;
                    case 5:
                        if (IsProjectFinished(targetProject))
                        {
                            break;
                        }

                        DeleteTask(projectDictionary[targetProject], targetProject);

                        if (IsAllTaskFinish(projectDictionary, targetProject))
                        {
                            targetProject.Status = Status.finish;
                        }
                        break;
                    case 6:
                        AproxTimeToFinishProject(projectDictionary[targetProject], targetProject.Name, targetProject.Status);
                        break;
                    default:
                        break;
                }
            }

        }
        static void PrintAllTaskInProject(List<ProjectTask> taskList, Project targetProject)
        {
            Console.Clear();
            Console.WriteLine($"Ispis svih zadataka unutar {targetProject.Name}\n");

            PrintTask(taskList);

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }
        static void PrintTask(List<ProjectTask> taskList)
        {
            Console.WriteLine("Naziv zadatka");
            foreach (var projectTask in taskList)
            {
                Console.WriteLine(projectTask.Name);
            }
        }

        static void ShowProjectDetails(Project targetProject)
        {
            Console.Clear();
            Console.WriteLine($"Detalji projekta {targetProject.Name}\n");

            Console.WriteLine("naziv projekta - opis - pocetak - kraj - status");
            targetProject.Print();
            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }
        static void ChangeProjectStatus(Project targetProject)
        {
            Console.Clear();
            Console.WriteLine($"Uredivanje statusa projekt {targetProject.Name}. Trenutni status projekta je: {targetProject.Status}");

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

            if (newStatus == targetProject.Status)
            {
                Console.WriteLine("Status ostaje isti.");
                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();

                return;
            }

            Console.Write($"jeste li sigurni da zelite promjeniti status iz {targetProject.Status} u {newStatus} (y/n): ");
            if (YNanswer())
            {
                targetProject.Status = newStatus;
                Console.WriteLine("\nStatus uspjesno promjenjen!");
            }
            else
            {
                Console.WriteLine("\nPonisteno!");
            }

            if (newStatus == Status.active)
            {
                if(targetProject.StartDate > DateTime.Now)
                {
                    targetProject.StartDate = DateTime.Now;
                }
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

            DateTime startRangeDate = targetProject.StartDate < DateTime.Now ? DateTime.Now : targetProject.StartDate;

            Console.Write("Unesi rok za izvrsenje (YYYY-MM-DD): ");
            var endDate = NewDate();
            while (endDate < DateTime.Now || endDate > targetProject.EndDate || endDate < targetProject.StartDate)
            {
                Console.Write($"rok za izvrsenje mora biti iz intervala ( {startRangeDate.ToString("yyyy-MM-dd")}, {targetProject.EndDate.ToString("yyyy-MM-dd")})! unos: (YYYY-MM-DD): ");
                endDate = NewDate();
            }

            var status = targetProject.StartDate<DateTime.Now ? StatusTask.active : StatusTask.delayed;

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

        static void DeleteTask(List<ProjectTask> taskList, Project targetProject)
        {
            Console.Clear();
            Console.WriteLine($"Brisanje zadatka iz projekta {targetProject.Name}\n");

            ProjectTask deleteTask = FindTask(taskList);

            if (deleteTask == null)
            {
                return;
            }

            Console.Write($"Jeste li sigurni da zelite izbrisati zadatak {deleteTask.Name} (y/n)? ");
            if (YNanswer())
            {

                taskList.Remove(deleteTask);

                Console.WriteLine($"\nUspjesno izbrisan.");
            }
            else
            {
                Console.WriteLine("\nPoništeno!");
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();

        }

        static ProjectTask FindTask(List<ProjectTask> taskList)
        {
            PrintTask(taskList);

            Console.Write("\nUnesi ime zadatka: ");
            var taskName = Console.ReadLine().ToLower();

            while (String.IsNullOrEmpty(taskName))
            {
                Console.Write("Neispravan unos: ");
                taskName = Console.ReadLine().ToLower();
            }

            if (!FindTaskName(taskList, taskName))
            {
                Console.WriteLine($"Ne postoji zadatak sa imenom: {taskName}");

                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();

                return null;
            }

            foreach (var element in taskList)
            {
                if (element.Name == taskName)
                {
                    return element;
                }
            }
            return null;
        }

        static void AproxTimeToFinishProject(List<ProjectTask> TaskList, string name, Status status)
        {
            Console.Clear();

            if (status == Status.finish)
            {
                Console.WriteLine($"Projekt {name} je završen, nema aktivnih zadataka.");
                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();
                return;
            }

            int time = 0;
            foreach (var projectTask in TaskList)
            {
                if (projectTask.Status != StatusTask.active)
                {
                    continue;
                }

                time += projectTask.Duration;
            }

            Console.WriteLine($"Ukupno očekivano vrijme potrebno za sve aktivne zadatke u projektu {name} je: {time}min");


            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }

        static bool IsAllTaskFinish(Dictionary<Project, List<ProjectTask>> projectDictionary, Project TargetProject)
        {
            foreach (var project in projectDictionary[TargetProject])
            {
                if (project.Status != StatusTask.finish)
                {
                    return false;
                }
            }

            return true;
        }

        static void TaskMenu(Dictionary<Project, List<ProjectTask>> projectDictionary)
        {
            Console.Clear();
            Console.WriteLine("Upravljanje pojedinim zadatkom\n");

            Project TargetProject = FindProject(projectDictionary);

            if (TargetProject == null)
            { 
                return;
            }

            if (IsProjectFinished(TargetProject))
            {
                return;
            }
            Console.WriteLine();
            ProjectTask TargetTask = FindTask(projectDictionary[TargetProject]);

            if (TargetTask == null)
            {
                return;
            }

            var userInput = 0;

            while (userInput != 3)
            {
                Console.Clear();
                Console.WriteLine($"Upravljanje zadatkom {TargetTask.Name} iz  {TargetProject.Name}\n");
                Console.WriteLine("1 - Prikaz detalja odabranog zadatka\n2 - Uređivanje statusa zadatka\n3 - Izlaz");

                userInput = NumInput(1, 3);

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Detalji zadatka {TargetTask.Name}\n");

                        Console.WriteLine("naziv zadatka - opis - rok za izvrsenje - status - prioritet - ocekivano vrijeme trajanja");
                        TargetTask.Print();

                        Console.WriteLine("\nStisni enter za nastavak...");
                        Console.ReadLine();

                        break;
                    case 2:
                        ChangeTaskStatus(TargetTask, TargetProject);
                        if(IsAllTaskFinish(projectDictionary, TargetProject))
                        {
                            TargetProject.Status = Status.finish;
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        static void ChangeTaskStatus(ProjectTask TargetTask, Project TargetProject)
        {
            Console.Clear();
            Console.WriteLine($"Uredivanje statusa zadatka {TargetTask.Name}. Trenutni status zadatka je: {TargetTask.Status}");

            var newStatus = InputTaskStatus();

            if (newStatus == TargetTask.Status)
            {
                Console.WriteLine("\nStatus ostaje isti.");
                Console.WriteLine("\nStisni enter za nastavak...");
                Console.ReadLine();

                return;
            }

            Console.Write($"jeste li sigurni da zelite promjeniti status iz {TargetTask.Status} u {newStatus} (y/n): ");
            if (YNanswer())
            {
                TargetTask.Status = newStatus;
                Console.WriteLine("\nStatus uspjesno promjenjen!");
            }
            else
            {
                Console.WriteLine("\nPonisteno!");
            }

            Console.WriteLine("\nStisni enter za nastavak...");
            Console.ReadLine();
        }
    }
}