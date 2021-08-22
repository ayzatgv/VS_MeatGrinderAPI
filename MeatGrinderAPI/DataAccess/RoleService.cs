using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MeatGrinderAPI.DataAccess
{
    public class RoleService : MyDataAccess
    {
        //
        public static List<Role> Roles_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Roles_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Role> roles;
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

                roles = Role.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return roles;
        }
    }
}