using System;
using System.Collections.Generic;
using System.Data;

namespace MeatGrinderAPI.Models
{
    public class Task
    {
        //
        private int _id;
        private string _task_name;
        private string _task_description;
        private string _task_status;
        private string _date_raised;
        private string _date_completed;
        private string _last_changed;
        private User _task_creator;
        private User _task_assigned_to;
        private string _service_date;
        private string _wo;
        private string _tt;
        private Site _site;
        private Category _category;
        private string _report;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Task_Name
        {
            get { return _task_name; }
            set { _task_name = value; }
        }
        public string Task_Description
        {
            get { return _task_description; }
            set { _task_description = value; }
        }
        public string Task_Status
        {
            get { return _task_status; }
            set { _task_status = value; }
        }
        public string Date_Raised
        {
            get { return _date_raised; }
            set { _date_raised = value; }
        }
        public string Date_Completed
        {
            get { return _date_completed; }
            set { _date_completed = value; }
        }
        public string Last_Changed
        {
            get { return _last_changed; }
            set { _last_changed = value; }
        }
        public User Task_Creator
        {
            get { return _task_creator; }
            set { _task_creator = value; }
        }
        public User Task_Assigned_To
        {
            get { return _task_assigned_to; }
            set { _task_assigned_to = value; }
        }
        public string Service_Date
        {
            get { return _service_date; }
            set { _service_date = value; }
        }
        public string WO
        {
            get { return _wo; }
            set { _wo = value; }
        }
        public string TT
        {
            get { return _tt; }
            set { _tt = value; }
        }
        public Site Site
        {
            get { return _site; }
            set { _site = value; }
        }
        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string Report
        {
            get { return _report; }
            set { _report = value; }
        }

        //
        public Task()
        {
            Task_Creator = new User();
            Task_Assigned_To = new User();
            Site = new Site();
            Category = new Category();
        }

        //
        public static List<Task> Convert(DataTable dataTable)
        {
            List<Task> results = new List<Task>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Task Convert(DataRow dataRow)
        {
            Task result = null;

            if (dataRow != null)
            {
                result = new Task();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Task_Name") && dataRow["Task_Name"] != DBNull.Value)
                    result.Task_Name = System.Convert.ToString(dataRow["Task_Name"]);
                if (dataRow.Table.Columns.Contains("Task_Description") && dataRow["Task_Description"] != DBNull.Value)
                    result.Task_Description = System.Convert.ToString(dataRow["Task_Description"]);
                if (dataRow.Table.Columns.Contains("Task_Status") && dataRow["Task_Status"] != DBNull.Value)
                    result.Task_Status = System.Convert.ToString(dataRow["Task_Status"]);
                if (dataRow.Table.Columns.Contains("Date_Raised") && dataRow["Date_Raised"] != DBNull.Value)
                    result.Date_Raised = System.Convert.ToString(dataRow["Date_Raised"]);
                if (dataRow.Table.Columns.Contains("Date_Completed") && dataRow["Date_Completed"] != DBNull.Value)
                    result.Date_Completed = System.Convert.ToString(dataRow["Date_Completed"]);
                if (dataRow.Table.Columns.Contains("Last_Changed") && dataRow["Last_Changed"] != DBNull.Value)
                    result.Last_Changed = System.Convert.ToString(dataRow["Last_Changed"]);
                if (dataRow.Table.Columns.Contains("Task_Creator_ID") && dataRow["Task_Creator_ID"] != DBNull.Value)
                    result.Task_Creator.ID = System.Convert.ToInt32(dataRow["Task_Creator_ID"]);
                if (dataRow.Table.Columns.Contains("Creator") && dataRow["Creator"] != DBNull.Value)
                    result.Task_Creator.Username = System.Convert.ToString(dataRow["Creator"]);
                if (dataRow.Table.Columns.Contains("Task_Assigned_To_ID") && dataRow["Task_Assigned_To_ID"] != DBNull.Value)
                    result.Task_Assigned_To.ID = System.Convert.ToInt32(dataRow["Task_Assigned_To_ID"]);
                if (dataRow.Table.Columns.Contains("Assigned") && dataRow["Assigned"] != DBNull.Value)
                    result.Task_Assigned_To.Username = System.Convert.ToString(dataRow["Assigned"]);
                if (dataRow.Table.Columns.Contains("Service_Date") && dataRow["Service_Date"] != DBNull.Value)
                    result.Service_Date = System.Convert.ToString(dataRow["Service_Date"]);
                if (dataRow.Table.Columns.Contains("WO") && dataRow["WO"] != DBNull.Value)
                    result.WO = System.Convert.ToString(dataRow["WO"]);
                if (dataRow.Table.Columns.Contains("TT") && dataRow["TT"] != DBNull.Value)
                    result.TT = System.Convert.ToString(dataRow["TT"]);
                if (dataRow.Table.Columns.Contains("Site_ID") && dataRow["Site_ID"] != DBNull.Value)
                    result.Site.ID = System.Convert.ToInt32(dataRow["Site_ID"]);
                if (dataRow.Table.Columns.Contains("Site_Name") && dataRow["Site_Name"] != DBNull.Value)
                    result.Site.Site_Name = System.Convert.ToString(dataRow["Site_Name"]);
                if (dataRow.Table.Columns.Contains("Address") && dataRow["Address"] != DBNull.Value)
                    result.Site.Address = System.Convert.ToString(dataRow["Address"]);
                if (dataRow.Table.Columns.Contains("Province") && dataRow["Province"] != DBNull.Value)
                    result.Site.Province = System.Convert.ToString(dataRow["Province"]);
                if (dataRow.Table.Columns.Contains("City") && dataRow["City"] != DBNull.Value)
                    result.Site.City = System.Convert.ToString(dataRow["City"]);
                if (dataRow.Table.Columns.Contains("Category_ID") && dataRow["Category_ID"] != DBNull.Value)
                    result.Category.ID = System.Convert.ToInt32(dataRow["Category_ID"]);
                if (dataRow.Table.Columns.Contains("Category_Name") && dataRow["Category_Name"] != DBNull.Value)
                    result.Category.Category_Name = System.Convert.ToString(dataRow["Category_Name"]);
                if (dataRow.Table.Columns.Contains("Report") && dataRow["Report"] != DBNull.Value)
                    result.Report = System.Convert.ToString(dataRow["Report"]);
            }
            return result;
        }
    }
    enum Task_Status
    {
        Open,
        Complete,
        Closed,
        Canceled
    }
}