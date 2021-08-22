using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeatGrinderAPI.DataAccess
{
    public class ClusterService : MyDataAccess
    {
        //
        public static List<Cluster> Clusters_Select(int id = 0, int user_id = 0, int site_id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Clusters_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _user_id = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter _site_id = new SqlParameter("@Site_ID", SqlDbType.Int);

            DataTable dataTable;
            List<Cluster> clusters;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;
                if (user_id != 0)
                    _user_id.Value = user_id;
                else
                    _user_id.Value = DBNull.Value;
                if (site_id != 0)
                    _site_id.Value = site_id;
                else
                    _site_id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_user_id);
                sqlCommand.Parameters.Add(_site_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                clusters = Cluster.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return clusters;
        }

        //
        public static int Clusters_Insert(Cluster cluster)
        {

            SqlCommand sqlCommand = GetCommand("Clusters_Insert");

            SqlParameter _user_id = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter _site_id = new SqlParameter("@Site_ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (cluster.User.ID != 0)
                    _user_id.Value = cluster.User.ID;
                else
                    _user_id.Value = DBNull.Value;
                if (cluster.Site.ID != 0)
                    _site_id.Value = cluster.Site.ID;
                else
                    _site_id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;


                sqlCommand.Parameters.Add(_user_id);
                sqlCommand.Parameters.Add(_site_id);
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
        public static int Clusters_Update(Cluster cluster)
        {
            SqlCommand sqlCommand = GetCommand("Clusters_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _user_id = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter _site_id = new SqlParameter("@Site_ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (cluster.ID != 0)
                    _id.Value = cluster.ID;
                else
                    _id.Value = DBNull.Value;

                if (cluster.User.ID != 0)
                    _user_id.Value = cluster.User.ID;
                else
                    _user_id.Value = DBNull.Value;
                if (cluster.Site.ID != 0)
                    _site_id.Value = cluster.Site.ID;
                else
                    _site_id.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_user_id);
                sqlCommand.Parameters.Add(_site_id);
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
        public static int Clusters_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Clusters_Delete");

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