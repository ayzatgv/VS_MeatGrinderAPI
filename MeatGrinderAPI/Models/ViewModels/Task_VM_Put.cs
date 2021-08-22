using System;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Put
    {
        public int ID { get; set; }
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public int Task_Assigned_To_ID { get; set; }
        public string Service_Date { get; set; }
        public string Task_Status { get; set; }
        public string WO { get; set; }
        public string TT { get; set; }
        public int Site_ID { get; set; }
        public int Category_ID { get; set; }

        public Task ConvertToModel()
        {
            Task task = new Task();

            if (this.ID != 0)
                task.ID = this.ID;
            if (!string.IsNullOrEmpty(Task_Name))
                task.Task_Name = this.Task_Name;
            if (!string.IsNullOrEmpty(Task_Description))
                task.Task_Description = this.Task_Description;
            if (!string.IsNullOrEmpty(Task_Status))
            {
                if (Task_Status == "Open" || Task_Status == "Canceled")
                {
                    task.Task_Status = this.Task_Status;
                    task.Date_Completed = "";
                }
                else
                {
                    task.Task_Status = this.Task_Status;
                }
            }
            task.Last_Changed = DateTime.Now.Date.ToString("d");
            if (this.Task_Assigned_To_ID != 0)
                task.Task_Assigned_To.ID = this.Task_Assigned_To_ID;
            if (!string.IsNullOrEmpty(this.Service_Date))
                task.Service_Date = this.Service_Date;
            if (!string.IsNullOrEmpty(this.WO))
                task.WO = this.WO.ToUpper();
            if (!string.IsNullOrEmpty(this.TT))
                task.TT = this.TT.ToUpper();
            if (this.Site_ID != 0)
                task.Site.ID = this.Site_ID;
            if (this.Category_ID != 0)
                task.Category.ID = this.Category_ID;


            return task;
        }
    }
}