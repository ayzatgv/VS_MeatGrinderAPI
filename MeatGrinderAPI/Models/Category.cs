using System;
using System.Collections.Generic;
using System.Data;

namespace MeatGrinderAPI.Models
{
    public class Category
    {
        //
        private int _id;
        private string _category_name;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Category_Name
        {
            get { return _category_name; }
            set { _category_name = value; }
        }

        //
        public Category()
        {

        }
        public Category(string category_name)
        {
            Category_Name = category_name;
        }

        //
        public static List<Category> Convert(DataTable dataTable)
        {
            List<Category> results = new List<Category>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Category Convert(DataRow dataRow)
        {
            Category result = null;

            if (dataRow != null)
            {
                result = new Category();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Category_Name") && dataRow["Category_Name"] != DBNull.Value)
                    result.Category_Name = System.Convert.ToString(dataRow["Category_Name"]);
            }
            return result;
        }
    }
}