using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using MeatGrinderAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeatGrinderAPI.DataAccess
{
    public class TaskService : MyDataAccess
    {
        //
        public static List<Task> Tasks_Select(int id = 0, int user_ID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Tasks_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _task_assigned_to_id = new SqlParameter("@Task_Assigned_To_ID", SqlDbType.Int);

            DataTable dataTable;
            List<Task> tasks;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;
                if (user_ID != 0)
                    _task_assigned_to_id.Value = user_ID;
                else
                    _task_assigned_to_id.Value = DBNull.Value;


                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_task_assigned_to_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                tasks = Task.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return tasks;
        }

        public static List<Task> Tasks_Search(string Username = null, string Category_Name = null, string Site_Name = null, string WO = null, string TT = null, string Status = null)
        {
            SqlCommand sqlCommand = GetCommand("Tasks_Search");

            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, -1);
            SqlParameter _category_name = new SqlParameter("@Category_Name", SqlDbType.NVarChar, -1);
            SqlParameter _site_name = new SqlParameter("@Site_Name", SqlDbType.NVarChar, -1);
            SqlParameter _wo = new SqlParameter("@WO", SqlDbType.NVarChar, -1);
            SqlParameter _tt = new SqlParameter("@TT", SqlDbType.NVarChar, -1);
            SqlParameter _status = new SqlParameter("@Status", SqlDbType.NVarChar, -1);

            DataTable dataTable;
            List<Task> tasks;
            try
            {
                if (!string.IsNullOrEmpty(Username))
                    _username.Value = Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(Category_Name))
                    _category_name.Value = Category_Name;
                else
                    _category_name.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(Site_Name))
                    _site_name.Value = Site_Name;
                else
                    _site_name.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(WO))
                    _wo.Value = WO;
                else
                    _wo.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(TT))
                    _tt.Value = TT;
                else
                    _tt.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(Status))
                    _status.Value = Status;
                else
                    _status.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_category_name);
                sqlCommand.Parameters.Add(_site_name);
                sqlCommand.Parameters.Add(_wo);
                sqlCommand.Parameters.Add(_tt);
                sqlCommand.Parameters.Add(_status);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                tasks = Task.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return tasks;
        }

        public static Task_VM_Count Tasks_Count(int user_id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Tasks_Count");

            SqlParameter _user_id = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter _total_tasks = new SqlParameter("@Total_Tasks", SqlDbType.Int);
            SqlParameter _sites_involved = new SqlParameter("@Sites_Involved", SqlDbType.Int);
            SqlParameter _open_tasks = new SqlParameter("@Open_Tasks", SqlDbType.Int);
            SqlParameter _complete_tasks = new SqlParameter("@Complete_Tasks", SqlDbType.Int);
            SqlParameter _closed_tasks = new SqlParameter("@Closed_Tasks", SqlDbType.Int);

            try
            {
                if (user_id != 0)
                    _user_id.Value = user_id;
                else
                    _user_id.Value = DBNull.Value;

                _total_tasks.Direction = ParameterDirection.Output;
                _sites_involved.Direction = ParameterDirection.Output;
                _open_tasks.Direction = ParameterDirection.Output;
                _complete_tasks.Direction = ParameterDirection.Output;
                _closed_tasks.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(_user_id);
                sqlCommand.Parameters.Add(_total_tasks);
                sqlCommand.Parameters.Add(_sites_involved);
                sqlCommand.Parameters.Add(_open_tasks);
                sqlCommand.Parameters.Add(_complete_tasks);
                sqlCommand.Parameters.Add(_closed_tasks);

                ExecuteNonQuery(sqlCommand);

                return new Task_VM_Count((int)_total_tasks.Value, (int)_sites_involved.Value, (int)_open_tasks.Value, (int)_complete_tasks.Value, (int)_closed_tasks.Value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //
        public static int Tasks_Insert(Task task)
        {

            SqlCommand sqlCommand = GetCommand("Tasks_Insert");

            SqlParameter _task_name = new SqlParameter("@Task_Name", SqlDbType.NVarChar, -1);
            SqlParameter _task_description = new SqlParameter("@Task_Description", SqlDbType.NVarChar, -1);
            SqlParameter _task_status = new SqlParameter("@Task_Status", SqlDbType.NVarChar, -1);
            SqlParameter _date_raised = new SqlParameter("@Date_Raised", SqlDbType.NVarChar, -1);
            SqlParameter _task_creator_id = new SqlParameter("@Task_Creator_ID", SqlDbType.Int);
            SqlParameter _task_assigned_to_id = new SqlParameter("@Task_Assigned_To_ID", SqlDbType.Int);
            SqlParameter _service_date = new SqlParameter("@Service_Date", SqlDbType.NVarChar, -1);
            SqlParameter _wo = new SqlParameter("@WO", SqlDbType.NVarChar, -1);
            SqlParameter _tt = new SqlParameter("@TT", SqlDbType.NVarChar, -1);
            SqlParameter _site_id = new SqlParameter("@Site_ID", SqlDbType.Int);
            SqlParameter _category_id = new SqlParameter("@Category_ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(task.Task_Name))
                    _task_name.Value = task.Task_Name;
                else
                    _task_name.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Task_Description))
                    _task_description.Value = task.Task_Description;
                else
                    _task_description.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Task_Status))
                    _task_status.Value = task.Task_Status;
                else
                    _task_status.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Date_Raised))
                    _date_raised.Value = task.Date_Raised;
                else
                    _date_raised.Value = DBNull.Value;

                if (task.Task_Creator.ID != 0)
                    _task_creator_id.Value = task.Task_Creator.ID;
                else
                    _task_creator_id.Value = DBNull.Value;

                if (task.Task_Assigned_To.ID != 0)
                    _task_assigned_to_id.Value = task.Task_Assigned_To.ID;
                else
                    _task_assigned_to_id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Service_Date))
                    _service_date.Value = task.Service_Date;
                else
                    _service_date.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.WO))
                    _wo.Value = task.WO;
                else
                    _wo.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.TT))
                    _tt.Value = task.TT;
                else
                    _tt.Value = DBNull.Value;

                if (task.Site.ID != 0)
                    _site_id.Value = task.Site.ID;
                else
                    _site_id.Value = DBNull.Value;

                if (task.Category.ID != 0)
                    _category_id.Value = task.Category.ID;
                else
                    _category_id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;


                sqlCommand.Parameters.Add(_task_name);
                sqlCommand.Parameters.Add(_task_description);
                sqlCommand.Parameters.Add(_task_status);
                sqlCommand.Parameters.Add(_date_raised);
                sqlCommand.Parameters.Add(_task_creator_id);
                sqlCommand.Parameters.Add(_task_assigned_to_id);
                sqlCommand.Parameters.Add(_service_date);
                sqlCommand.Parameters.Add(_wo);
                sqlCommand.Parameters.Add(_tt);
                sqlCommand.Parameters.Add(_site_id);
                sqlCommand.Parameters.Add(_category_id);
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
        public static int Tasks_Update(Task task)
        {
            SqlCommand sqlCommand = GetCommand("Tasks_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _task_name = new SqlParameter("@Task_Name", SqlDbType.NVarChar, -1);
            SqlParameter _task_description = new SqlParameter("@Task_Description", SqlDbType.NVarChar, -1);
            SqlParameter _task_status = new SqlParameter("@Task_Status", SqlDbType.NVarChar, -1);
            SqlParameter _date_completed = new SqlParameter("@Date_Completed", SqlDbType.NVarChar, -1);
            SqlParameter _last_changed = new SqlParameter("@Last_Changed", SqlDbType.NVarChar, -1);
            SqlParameter _task_assigned_to_id = new SqlParameter("@Task_Assigned_To_ID", SqlDbType.Int);
            SqlParameter _service_date = new SqlParameter("@Service_Date", SqlDbType.NVarChar, -1);
            SqlParameter _wo = new SqlParameter("@WO", SqlDbType.NVarChar, -1);
            SqlParameter _tt = new SqlParameter("@TT", SqlDbType.NVarChar, -1);
            SqlParameter _site_id = new SqlParameter("@Site_ID", SqlDbType.Int);
            SqlParameter _category_id = new SqlParameter("Category_ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (task.ID != 0)
                    _id.Value = task.ID;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(task.Task_Name))
                    _task_name.Value = task.Task_Name;
                else
                    _task_name.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Task_Description))
                    _task_description.Value = task.Task_Description;
                else
                    _task_description.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Task_Status))
                    _task_status.Value = task.Task_Status;
                else
                    _task_status.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Date_Completed))
                    _date_completed.Value = task.Date_Completed;
                else
                    _date_completed.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Last_Changed))
                    _last_changed.Value = task.Last_Changed;
                else
                    _last_changed.Value = DBNull.Value;

                if (task.Task_Assigned_To.ID != 0)
                    _task_assigned_to_id.Value = task.Task_Assigned_To.ID;
                else
                    _task_assigned_to_id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.Service_Date))
                    _service_date.Value = task.Service_Date;
                else
                    _service_date.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.WO))
                    _wo.Value = task.WO;
                else
                    _wo.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(task.TT))
                    _tt.Value = task.TT;
                else
                    _tt.Value = DBNull.Value;

                if (task.Category.ID != 0)
                    _site_id.Value = task.Site.ID;
                else
                    _site_id.Value = DBNull.Value;

                if (task.Category.ID != 0)
                    _category_id.Value = task.Category.ID;
                else
                    _category_id.Value = DBNull.Value;



                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_task_name);
                sqlCommand.Parameters.Add(_task_description);
                sqlCommand.Parameters.Add(_task_status);
                sqlCommand.Parameters.Add(_date_completed);
                sqlCommand.Parameters.Add(_last_changed);
                sqlCommand.Parameters.Add(_task_assigned_to_id);
                sqlCommand.Parameters.Add(_service_date);
                sqlCommand.Parameters.Add(_wo);
                sqlCommand.Parameters.Add(_tt);
                sqlCommand.Parameters.Add(_site_id);
                sqlCommand.Parameters.Add(_category_id);
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
        public static int Tasks_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Tasks_Delete");

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