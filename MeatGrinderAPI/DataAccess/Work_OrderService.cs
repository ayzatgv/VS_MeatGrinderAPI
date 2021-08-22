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
    public class Work_OrderService : MyDataAccess
    {
        public static List<Work_Order> Work_Orders_Select_Open()
        {
            SqlCommand sqlCommand = GetCommand("Work_Orders_Select_Open");

            DataTable dataTable;
            List<Work_Order> results;
            try
            {


                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                results = Work_Order.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return results;
        }
        public static List<Work_Order> Work_Orders_Select_Open7Day()
        {
            SqlCommand sqlCommand = GetCommand("Work_Orders_Select_Open7Day");

            DataTable dataTable;
            List<Work_Order> results;
            try
            {


                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                results = Work_Order.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return results;
        }
        public static List<Work_Order> Work_Orders_Select_OpenSLApass()
        {
            SqlCommand sqlCommand = GetCommand("Work_Orders_Select_OpenSLApass");

            DataTable dataTable;
            List<Work_Order> results;
            try
            {


                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                results = Work_Order.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return results;
        }
        public static List<Work_Order> Work_Orders_Select_CompletePass()
        {
            SqlCommand sqlCommand = GetCommand("Work_Orders_Select_CompletePass");

            DataTable dataTable;
            List<Work_Order> results;
            try
            {


                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                results = Work_Order.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return results;
        }
    }
}