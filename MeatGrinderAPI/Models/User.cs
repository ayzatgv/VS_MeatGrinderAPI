using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;

namespace MeatGrinderAPI.Models
{
    public class User
    {
        //
        private int _id;
        private string _username;
        private string _password;
        private string _passwordSalt;
        private Role _role;
        private bool _isDeleted;

        //
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        //
        public User()
        {
            Role = new Role();
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //
        public static List<User> Convert(DataTable dataTable)
        {
            List<User> results = new List<User>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    results.Add(Convert(item));
                }
            }
            return results;
        }
        public static User Convert(DataRow dataRow)
        {
            User result = null;

            if (dataRow != null)
            {
                result = new User();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("Password") && dataRow["Password"] != DBNull.Value)
                    result.Password = System.Convert.ToString(dataRow["Password"]);
                if (dataRow.Table.Columns.Contains("PasswordSalt") && dataRow["PasswordSalt"] != DBNull.Value)
                    result.PasswordSalt = System.Convert.ToString(dataRow["PasswordSalt"]);
                if (dataRow.Table.Columns.Contains("Role_ID") && dataRow["Role_ID"] != DBNull.Value)
                    result.Role.ID = System.Convert.ToInt32(dataRow["Role_ID"]);
                if (dataRow.Table.Columns.Contains("Role_Name") && dataRow["Role_Name"] != DBNull.Value)
                    result.Role.Role_Name = System.Convert.ToString(dataRow["Role_Name"]);
                if (dataRow.Table.Columns.Contains("IsDeleted") && dataRow["IsDeleted"] != DBNull.Value)
                    result.IsDeleted = System.Convert.ToBoolean(dataRow["IsDeleted"]);
            }
            return result;
        }
        public string HashedPassword(string password)
        {
            var saltedPassword = password + PasswordSalt;
            var saltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            var hashedPassword = System.Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordByBytes));
            return hashedPassword;
        }
    }
}