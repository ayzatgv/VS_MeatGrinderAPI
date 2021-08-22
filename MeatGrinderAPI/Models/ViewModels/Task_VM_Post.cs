using System;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Post
    {
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public int Task_Assigned_To_ID { get; set; }
        public string Service_Date { get; set; }
        public string WO { get; set; }
        public string TT { get; set; }
        public int Site_ID { get; set; }
        public int Category_ID { get; set; }

        public Task ConvertToModel(int user_id)
        {
            Task task = new Task();

            if (!string.IsNullOrEmpty(this.Task_Name))
                task.Task_Name = this.Task_Name;
            if (!string.IsNullOrEmpty(this.Task_Description))
                task.Task_Description = this.Task_Description;
            task.Task_Status = "Open";
            task.Date_Raised = DateTime.Now.Date.ToString("d");
            if (user_id != 0)
                task.Task_Creator.ID = user_id;
            if (Task_Assigned_To_ID != 0)
                task.Task_Assigned_To.ID = this.Task_Assigned_To_ID;
            if (!string.IsNullOrEmpty(this.Service_Date))
                task.Service_Date = this.Service_Date;
            if (!string.IsNullOrEmpty(this.WO))
                task.WO = this.WO.ToUpper(); ;
            if (!string.IsNullOrEmpty(this.TT))
                task.TT = this.TT.ToUpper();
            if (Site_ID != 0)
                task.Site.ID = this.Site_ID;
            if (Category_ID != 0)
                task.Category.ID = this.Category_ID;

            return task;
        }
    }
}