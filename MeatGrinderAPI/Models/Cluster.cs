using System;
using System.Collections.Generic;
using System.Data;

namespace MeatGrinderAPI.Models
{
    public class Cluster
    {
        //
        private int _id;
        private User _user;
        private Site _site;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public Site Site
        {
            get { return _site; }
            set { _site = value; }
        }

        //
        public Cluster()
        {
            User = new User();
            Site = new Site();
        }
        public Cluster(int user_id, int site_id)
        {
            User = new User
            {
                ID = user_id
            };
            Site = new Site
            {
                ID = site_id
            };
        }
        //
        public static List<Cluster> Convert(DataTable dataTable)
        {
            List<Cluster> results = new List<Cluster>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Cluster Convert(DataRow dataRow)
        {
            Cluster result = null;

            if (dataRow != null)
            {
                result = new Cluster();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("User_ID") && dataRow["User_ID"] != DBNull.Value)
                    result.User.ID = System.Convert.ToInt32(dataRow["User_ID"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.User.Username = System.Convert.ToString(dataRow["Username"]);
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
            }
            return result;
        }
    }
}