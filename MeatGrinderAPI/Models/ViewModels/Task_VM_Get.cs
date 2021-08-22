using System;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Get
    {
        public int ID { get; set; }
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public string Task_Status { get; set; }
        public string Date_Raised { get; set; }
        public string Date_Completed { get; set; }
        public string Last_Changed { get; set; }
        public int Task_Creator_ID { get; set; }
        public string Task_Creator_Username { get; set; }
        public int Task_Assigned_To_ID { get; set; }
        public string Task_Assigned_To_Username { get; set; }
        public string Service_Date { get; set; }
        public string WO { get; set; }
        public string TT { get; set; }
        public Site Site { get; set; }
        public Category Category { get; set; }

        // CSS
        public bool TaskDue { get; set; }
        public string TaskDueColor { get; set; }


        public Task_VM_Get(Task task)
        {
            this.ID = task.ID;
            this.Task_Name = task.Task_Name;
            this.Task_Description = task.Task_Description;
            this.Task_Status = task.Task_Status;
            this.Date_Raised = task.Date_Raised;
            this.Date_Completed = task.Date_Completed;
            this.Last_Changed = task.Last_Changed;
            this.Task_Creator_ID = task.Task_Creator.ID;
            this.Task_Creator_Username = task.Task_Creator.Username;
            this.Task_Assigned_To_ID = task.Task_Assigned_To.ID;
            this.Task_Assigned_To_Username = task.Task_Assigned_To.Username;
            this.Service_Date = task.Service_Date;
            this.WO = task.WO;
            this.TT = task.TT;
            this.Site = task.Site;
            this.Category = task.Category;

            // CSS
            if (Date_Completed == null && DateTime.Compare(DateTime.Now.Date, DateTime.Parse(Service_Date)) > 0)
            {
                TaskDue = true;
                TaskDueColor = "red";
            }
            else if (Date_Completed != null && DateTime.Compare(DateTime.Parse(Date_Completed), DateTime.Parse(Service_Date)) > 0)
            {
                TaskDue = true;
                TaskDueColor = "blue";
            }
            else TaskDue = false;
        }
    }
}