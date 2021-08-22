namespace MeatGrinderAPI.Models.ViewModels
{
    public class User_VM_EditUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            if (this.ID != 0)
                user.ID = this.ID;
            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
                user.Password = this.Password;
            if (this.Role_ID != 0)
                user.Role.ID = this.Role_ID;

            return user;
        }
    }
}