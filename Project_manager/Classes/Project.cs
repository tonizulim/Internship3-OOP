using Project_manager_app.Enum;
using System;


namespace Project_manager_app.Classes
{
    internal class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }


        public Project(string name, string description, DateTime startDate, DateTime endDate, Status status)
        {
            Name = name;
            Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Status = status;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} - {Description} - {StartDate.ToString("yyyy-MM-dd")} - {EndDate.ToString("yyyy-MM-dd")} - {Status}");
        }
    }
}
