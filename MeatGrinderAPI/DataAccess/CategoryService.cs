using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeatGrinderAPI.DataAccess
{
    public class CategoryService : MyDataAccess
    {
        //
        public static List<Category> Categories_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Categories_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Category> categories;
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

                categories = Category.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return categories;
        }

        //
        public static int Categories_Insert(Category category)
        {

            SqlCommand sqlCommand = GetCommand("Categories_Insert");

            SqlParameter _category_name = new SqlParameter("@Category_Name", SqlDbType.NVarChar, -1);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(category.Category_Name))
                    _category_name.Value = category.Category_Name;
                else
                    _category_name.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;


                sqlCommand.Parameters.Add(_category_name);
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
        public static int Categories_Update(Category category)
        {
            SqlCommand sqlCommand = GetCommand("Categories_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _category_name = new SqlParameter("@Category_Name", SqlDbType.NVarChar, -1);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (category.ID != 0)
                    _id.Value = category.ID;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(category.Category_Name))
                    _category_name.Value = category.Category_Name;
                else
                    _category_name.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_category_name);
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
        public static int Categories_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Categories_Delete");

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