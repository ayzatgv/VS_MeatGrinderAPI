using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Count
    {
        public int Total_Tasks { get; set; }
        public int Sites_Involved { get; set; }
        public int Open_Tasks { get; set; }
        public int Complete_Tasks { get; set; }
        public int Closed_Tasks { get; set; }

        public Task_VM_Count(int total_tasks, int sites_involved, int open_tasks, int complete_tasks, int closed_tasks)
        {
            Total_Tasks = total_tasks;
            Sites_Involved = sites_involved;
            Open_Tasks = open_tasks;
            Complete_Tasks = complete_tasks;
            Closed_Tasks = closed_tasks;
        }
    }
}