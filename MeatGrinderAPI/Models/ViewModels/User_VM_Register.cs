using System;

namespace MeatGrinderAPI.Models.ViewModels
{
    public class User_VM_Register
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
            {
                user.PasswordSalt = Guid.NewGuid().ToString("N");
                user.Password = user.HashedPassword(this.Password);
            }
            if (Role_ID != 0)
                user.Role.ID = this.Role_ID;

            return user;
        }
    }
}