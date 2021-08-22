using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Status
    {
        public int ID { get; set; }
        public string Task_Status { get; set; }

        public Task ConvertToModel()
        {
            Task task = new Task();

            if (this.ID != 0)
                task.ID = this.ID;

            if (!string.IsNullOrEmpty(this.Task_Status))
            {
                if (Task_Status == "Open")
                {
                    task.Date_Completed = "";
                    task.Task_Status = this.Task_Status;

                }
                else if (Task_Status == "Complete")
                {
                    task.Date_Completed = DateTime.Now.Date.ToString("d");
                    task.Task_Status = this.Task_Status;
                }
            }

            return task;
        }
    }
}