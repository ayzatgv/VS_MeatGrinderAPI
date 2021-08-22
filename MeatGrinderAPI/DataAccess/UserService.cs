using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeatGrinderAPI.DataAccess
{
    public class UserService : MyDataAccess
    {
        //
        public static List<User> Users_Select(int id = 0, string username = null, int role_id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Users_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, -1);
            SqlParameter _role_id = new SqlParameter("@Role_ID", SqlDbType.Int);

            DataTable dataTable;
            List<User> users;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(username))
                    _username.Value = username;
                else
                    _username.Value = DBNull.Value;

                if (role_id != 0)
                    _role_id.Value = role_id;
                else
                    _role_id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_role_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                users = User.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        //
        public static int Users_Insert(User user)
        {

            SqlCommand sqlCommand = GetCommand("Users_Insert");

            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, -1);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, -1);
            SqlParameter _passwordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, -1);
            SqlParameter _role_id = new SqlParameter("@Role_ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(user.PasswordSalt))
                    _passwordSalt.Value = user.PasswordSalt;
                else
                    _passwordSalt.Value = DBNull.Value;
                if (user.Role.ID != 0)
                    _role_id.Value = user.Role.ID;
                else
                    _role_id.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_passwordSalt);
                sqlCommand.Parameters.Add(_role_id);
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
        public static int Users_Update(User user)
        {
            SqlCommand sqlCommand = GetCommand("Users_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, -1);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, -1);
            SqlParameter _role_id = new SqlParameter("@Role_ID", SqlDbType.Int);
            SqlParameter _isDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (user.ID != 0)
                    _id.Value = user.ID;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;

                if (user.Role.ID != 0)
                    _role_id.Value = user.Role.ID;
                else
                    _role_id.Value = DBNull.Value;

                if (user.IsDeleted)
                    _isDeleted.Value = 1;
                else
                    _isDeleted.Value = 0;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_role_id);
                sqlCommand.Parameters.Add(_isDeleted);
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