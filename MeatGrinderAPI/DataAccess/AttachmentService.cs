using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MeatGrinderAPI.DataAccess
{
    public class AttachmentService : MyDataAccess
    {
        public static List<Attachment> Attachments_Select(int id = 0, int task_ID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Attachments_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _task_id = new SqlParameter("@Task_ID", SqlDbType.Int);

            DataTable dataTable;
            List<Attachment> attachments;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                if (task_ID != 0)
                    _task_id.Value = task_ID;
                else
                    _task_id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_task_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                attachments = Attachment.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return attachments;
        }

        //
        public static int Attachments_Insert(Attachment attachment)
        {

            SqlCommand sqlCommand = GetCommand("Attachments_Insert");

            SqlParameter _task_id = new SqlParameter("@Site_Name", SqlDbType.Int);
            SqlParameter _path = new SqlParameter("@Address", SqlDbType.NVarChar, -1);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (attachment.Task_ID != 0)
                    _task_id.Value = attachment.Task_ID;
                else
                    _task_id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(attachment.Path))
                    _path.Value = attachment.Path;
                else
                    _path.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_task_id);
                sqlCommand.Parameters.Add(_path);
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
        public static int Attachments_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Attachments_Delete");

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