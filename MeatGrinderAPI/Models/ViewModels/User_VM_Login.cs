namespace MeatGrinderAPI.Models.ViewModels
{
    public class User_VM_Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
                user.Password = this.Password;

            return user;
        }
    }
}