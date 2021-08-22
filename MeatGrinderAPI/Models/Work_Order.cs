using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.Models
{
    public class Work_Order
    {
        //
        private int _id;
        private string _code;
        private string _description;
        private string _date_raised;
        private Site _site;
        private string _service_date;
        private string _status_description;
        private int _priority;
        private string _category;
        private string _date_closed;
        private string _last_change_date;
        private string _type_releted_to;
        private string _complete_date;
        private string _username;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Date_Raised
        {
            get { return _date_raised; }
            set { _date_raised = value; }
        }
        public Site Site
        {
            get { return _site; }
            set { _site = value; }
        }
        public string Service_Date
        {
            get { return _service_date; }
            set { _service_date = value; }
        }
        public string Status_Description
        {
            get { return _status_description; }
            set { _status_description = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string Date_Closed
        {
            get { return _date_closed; }
            set { _date_closed = value; }
        }
        public string Last_Change_Date
        {
            get { return _last_change_date; }
            set { _last_change_date = value; }
        }
        public string Type_Releted_To
        {
            get { return _type_releted_to; }
            set { _type_releted_to = value; }
        }
        public string Complete_Date
        {
            get { return _complete_date; }
            set { _complete_date = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        // CSS
        public bool TaskDue { get; set; }

        //
        public Work_Order()
        {
            Site = new Site();
        }

        //
        public static List<Work_Order> Convert(DataTable dataTable)
        {
            List<Work_Order> results = new List<Work_Order>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Work_Order Convert(DataRow dataRow)
        {
            Work_Order result = null;

            if (dataRow != null)
            {
                result = new Work_Order();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Code") && dataRow["Code"] != DBNull.Value)
                    result.Code = System.Convert.ToString(dataRow["Code"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Description = System.Convert.ToString(dataRow["Description"]);
                if (dataRow.Table.Columns.Contains("Date_Raised") && dataRow["Date_Raised"] != DBNull.Value)
                    result.Date_Raised = System.Convert.ToString(dataRow["Date_Raised"]);
                if (dataRow.Table.Columns.Contains("Site_ID") && dataRow["Site_ID"] != DBNull.Value)
                    result.Site.ID = System.Convert.ToInt32(dataRow["Site_ID"]);
                if (dataRow.Table.Columns.Contains("Location") && dataRow["Location"] != DBNull.Value)
                    result.Site.Site_Name = System.Convert.ToString(dataRow["Location"]);
                if (dataRow.Table.Columns.Contains("Province") && dataRow["Province"] != DBNull.Value)
                    result.Site.Province = System.Convert.ToString(dataRow["Province"]);
                if (dataRow.Table.Columns.Contains("City") && dataRow["City"] != DBNull.Value)
                    result.Site.City = System.Convert.ToString(dataRow["City"]);
                if (dataRow.Table.Columns.Contains("Service_Date") && dataRow["Service_Date"] != DBNull.Value)
                    result.Service_Date = System.Convert.ToString(dataRow["Service_Date"]);
                if (dataRow.Table.Columns.Contains("Status_Description") && dataRow["Status_Description"] != DBNull.Value)
                    result.Status_Description = System.Convert.ToString(dataRow["Status_Description"]);
                if (dataRow.Table.Columns.Contains("Priority") && dataRow["Priority"] != DBNull.Value)
                    result.Priority = System.Convert.ToInt32(dataRow["Priority"]);
                if (dataRow.Table.Columns.Contains("Category") && dataRow["Category"] != DBNull.Value)
                    result.Category = System.Convert.ToString(dataRow["Category"]);
                if (dataRow.Table.Columns.Contains("Date_Closed") && dataRow["Date_Closed"] != DBNull.Value)
                    result.Date_Closed = System.Convert.ToString(dataRow["Date_Closed"]);
                if (dataRow.Table.Columns.Contains("Last_Change_Date") && dataRow["Last_Change_Date"] != DBNull.Value)
                    result.Last_Change_Date = System.Convert.ToString(dataRow["Last_Change_Date"]);
                if (dataRow.Table.Columns.Contains("Type_Releted_To") && dataRow["Type_Releted_To"] != DBNull.Value)
                    result.Type_Releted_To = System.Convert.ToString(dataRow["Type_Releted_To"]);
                if (dataRow.Table.Columns.Contains("Complete_Date") && dataRow["Complete_Date"] != DBNull.Value)
                    result.Complete_Date = System.Convert.ToString(dataRow["Complete_Date"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.Username = System.Convert.ToString(dataRow["Username"]);

                // CSS
                if (result.Status_Description == "Open" && DateTime.Compare(DateTime.Now.Date, DateTime.ParseExact(result.Service_Date, "yyyyMMdd", CultureInfo.InvariantCulture)) > 0)
                {
                    result.TaskDue = true;
                }
                else result.TaskDue = false;

            }
            return result;
        }

    }
}