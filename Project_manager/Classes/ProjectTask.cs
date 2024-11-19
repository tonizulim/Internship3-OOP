using Project_manager.Enum;
using Project_manager_app.Enum;
using System;


namespace Project_manager_app.Classes
{
    internal class ProjectTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public StatusTask Status { get; set; }

        public TaskPriority Priority { get; set; }
        public int Duration { get; set; }
        private string Project { get; set; }



        public ProjectTask(string name, string description, DateTime endDate, StatusTask status, TaskPriority priority, int Duration, string Project)
        {
            Name = name;
            Description = description;
            this.EndDate = endDate;
            this.Status = status;
            this.Priority = priority;
            this.Duration = Duration;
            this.Project = Project;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} - {Description} - {EndDate.ToString("yyyy-MM-dd")} - {Status} - {Priority} - {Duration}min - from {Project}");
        }
    }
}
