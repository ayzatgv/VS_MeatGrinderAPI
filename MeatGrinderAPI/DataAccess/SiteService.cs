using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeatGrinderAPI.DataAccess
{
    public class SiteService : MyDataAccess
    {
        //
        public static List<Site> Sites_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Sites_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Site> sites;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                sites = Site.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return sites;
        }

        //
        public static int Sites_Insert(Site site)
        {

            SqlCommand sqlCommand = GetCommand("Sites_Insert");

            SqlParameter _site_name = new SqlParameter("@Site_Name", SqlDbType.NVarChar, -1);
            SqlParameter _address = new SqlParameter("@Address", SqlDbType.NVarChar, -1);
            SqlParameter _province = new SqlParameter("@Province", SqlDbType.NVarChar, -1);
            SqlParameter _city = new SqlParameter("@City", SqlDbType.NVarChar, -1);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
               
                if (!string.IsNullOrEmpty(site.Site_Name))
                    _site_name.Value = site.Site_Name;
                else
                    _site_name.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.Address))
                    _address.Value = site.Address;
                else
                    _address.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.Province))
                    _province.Value = site.Province;
                else
                    _province.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.City))
                    _city.Value = site.City;
                else
                    _city.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;


                sqlCommand.Parameters.Add(_site_name);
                sqlCommand.Parameters.Add(_address);
                sqlCommand.Parameters.Add(_province);
                sqlCommand.Parameters.Add(_city);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        //
        public static int Sites_Update(Site site)
        {
            SqlCommand sqlCommand = GetCommand("Sites_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _site_name = new SqlParameter("@Site_Name", SqlDbType.NVarChar, -1);
            SqlParameter _address = new SqlParameter("@Address", SqlDbType.NVarChar, -1);
            SqlParameter _province = new SqlParameter("@Province", SqlDbType.NVarChar, -1);
            SqlParameter _city = new SqlParameter("@City", SqlDbType.NVarChar, -1);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (site.ID != 0)
                    _id.Value = site.ID;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.Site_Name))
                    _site_name.Value = site.Site_Name;
                else
                    _site_name.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.Address))
                    _address.Value = site.Address;
                else
                    _address.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.Province))
                    _province.Value = site.Province;
                else
                    _province.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(site.City))
                    _city.Value = site.City;
                else
                    _city.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_site_name);
                sqlCommand.Parameters.Add(_address);
                sqlCommand.Parameters.Add(_province);
                sqlCommand.Parameters.Add(_city);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        //
        public static int Sites_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Sites_Delete");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }
    }
}