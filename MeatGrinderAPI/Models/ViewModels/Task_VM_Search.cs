using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class Task_VM_Search
    {
        public string FME { get; set; }
        public string Category { get; set; }
        public string Site { get; set; }
        public string WO { get; set; }
        public string TT { get; set; }
        public string Status { get; set; }
    }
}