using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.Models
{
    public class Attachment
    {
        //
        private int _id;
        private int _task_ID;
        private string _path;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Task_ID
        {
            get { return _task_ID; }
            set { _task_ID = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        //
        public Attachment()
        {

        }

        //
        public static List<Attachment> Convert(DataTable dataTable)
        {
            List<Attachment> results = new List<Attachment>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Attachment Convert(DataRow dataRow)
        {
            Attachment result = null;

            if (dataRow != null)
            {
                result = new Attachment();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Task_ID") && dataRow["Task_ID"] != DBNull.Value)
                    result.Task_ID = System.Convert.ToInt32(dataRow["Task_ID"]);
                if (dataRow.Table.Columns.Contains("Path") && dataRow["Path"] != DBNull.Value)
                    result.Path = System.Convert.ToString(dataRow["Path"]);
            }
            return result;
        }
    }
}