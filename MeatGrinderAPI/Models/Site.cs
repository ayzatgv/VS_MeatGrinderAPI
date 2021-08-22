using System;
using System.Collections.Generic;
using System.Data;

namespace MeatGrinderAPI.Models
{
    public class Site
    {
        //
        private int _id;
        private string _site_name;
        private string _address;
        private string _province;
        private string _city;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Site_Name
        {
            get { return _site_name; }
            set { _site_name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        //
        public Site()
        {

        }

        //
        public static List<Site> Convert(DataTable dataTable)
        {
            List<Site> results = new List<Site>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static Site Convert(DataRow dataRow)
        {
            Site result = null;

            if (dataRow != null)
            {
                result = new Site();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Site_Name") && dataRow["Site_Name"] != DBNull.Value)
                    result.Site_Name = System.Convert.ToString(dataRow["Site_Name"]);
                if (dataRow.Table.Columns.Contains("Address") && dataRow["Address"] != DBNull.Value)
                    result.Address = System.Convert.ToString(dataRow["Address"]);
                if (dataRow.Table.Columns.Contains("Province") && dataRow["Province"] != DBNull.Value)
                    result.Province = System.Convert.ToString(dataRow["Province"]);
                if (dataRow.Table.Columns.Contains("City") && dataRow["City"] != DBNull.Value)
                    result.City = System.Convert.ToString(dataRow["City"]);
            }
            return result;
        }
    }
}