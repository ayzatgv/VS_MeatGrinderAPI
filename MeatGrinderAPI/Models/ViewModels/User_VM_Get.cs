namespace MeatGrinderAPI.Models.ViewModels
{
    public class User_VM_Get
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }

        public User_VM_Get(User user)
        {
            this.ID = user.ID;
            this.Username = user.Username;
            this.Role_ID = user.Role.ID;
            this.Role_Name = user.Role.Role_Name;
        }
    }
}