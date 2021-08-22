using System;
using System.Collections.Generic;
using System.Data;

namespace MeatGrinderAPI.Models
{
    public class Role
    {
        //
        private int _id;
        private string _role_name;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Role_Name
        {
            get { return _role_name; }
            set { _role_name = value; }
        }

        //
        public Role()
        {

        }
        public Role(int id, string role_name)
        {
            ID = id;
            Role_Name = role_name;
        }

        //
        public static List<Role> Convert(DataTable dataTable)
        {
            List<Role> results = new List<Role>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Role Convert(DataRow dataRow)
        {
            Role result = null;

            if (dataRow != null)
            {
                result = new Role();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Role_Name") && dataRow["Role_Name"] != DBNull.Value)
                    result.Role_Name = System.Convert.ToString(dataRow["Role_Name"]);
            }
            return result;
        }
    }
}